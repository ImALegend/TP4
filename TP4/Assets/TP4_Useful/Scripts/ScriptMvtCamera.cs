using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScriptMvtCamera : MonoBehaviour
{
    Rigidbody body { get; set; }
    bool locked;
    Camera Cam { get; set; }
    float posTeteAvant = 0;
    float posTeteLat = 0;
    [SerializeField]
    const float VITESSE_J = 200f;
    // Start is called before the first frame update
    void Start()
    {
        body = this.transform.GetComponentInChildren<Rigidbody>();
        Cam = this.GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            body.AddForce(Vector3.ProjectOnPlane(this.transform.forward, Vector3.up) * VITESSE_J * 60f*Time.deltaTime);
            posTeteAvant += Time.deltaTime;
            Cam.transform.position += this.transform.TransformVector(1 / 50f * Mathf.Sin(8f * posTeteAvant), 1/100f * Mathf.Sin(16f * posTeteAvant), 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            body.AddForce(Vector3.ProjectOnPlane(-this.transform.forward, Vector3.up) * VITESSE_J * 60f*Time.deltaTime);
            posTeteAvant -= Time.deltaTime;
            Cam.transform.position -= this.transform.TransformVector(1 / 50f * Mathf.Sin(8f * posTeteAvant), 1 / 100f * Mathf.Sin(16f * posTeteAvant), 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(Vector3.ProjectOnPlane(-this.transform.right, Vector3.up) * VITESSE_J/2 * 60f * Time.deltaTime);
            posTeteLat += Time.deltaTime;
            Cam.transform.position -= this.transform.TransformVector(0, 1 / 100f * Mathf.Sin(12f * posTeteLat), 1 / 200f * Mathf.Sin(6f * posTeteLat));
            //this.transform.Rotate(this.transform.up, -0.75f - body.velocity.magnitude * 0.01f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            body.AddForce(Vector3.ProjectOnPlane(this.transform.right, Vector3.up) * VITESSE_J/2 * 60f * Time.deltaTime);
            posTeteLat -= Time.deltaTime;
            Cam.transform.position -= this.transform.TransformVector(0, 1 / 200f * Mathf.Sin(12f * posTeteLat), 1 / 400f * Mathf.Sin(6f * posTeteLat));
            //this.transform.Rotate(this.transform.up, 0.75f + body.velocity.magnitude * 0.01f);
        }

        if (Input.GetKey("space"))
        {
#if UNITY_EDITOR
            Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked);
#else
         Application.Quit();
#endif
        }

        if (Input.GetKey("escape"))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        }

        if (Input.GetKey(KeyCode.F2))
        {
            body.transform.position = new Vector3(656f, 153f, -104f);
        }

        this.transform.Rotate(-Cam.transform.right * Screen.dpi, Input.GetAxis("Mouse Y")*3, Space.World);
        this.transform.Rotate(Vector3.up / Screen.dpi, Input.GetAxis("Mouse X")*4, Space.World);

    }
}
