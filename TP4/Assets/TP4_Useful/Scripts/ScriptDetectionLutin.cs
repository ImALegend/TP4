using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDetectionLutin : MonoBehaviour
{
    bool joueurMort;
    float temps;
    AudioSource Son { get; set; }
    GameObject Joueur { get; set; }
    [SerializeField]
    public static Vector3 POSITIONLIT { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Son = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AudioSource>();
        POSITIONLIT = new Vector3(1185, 0, -494);
    }

    // Update is called once per frame
    void Update()
    {
        if (joueurMort)
        {
            temps += Time.deltaTime/4;
            Joueur.transform.GetComponentInChildren<Camera>().fieldOfView /= 1 + Time.deltaTime/2;
            TuerJoueur(temps);
            Son.Play();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            joueurMort = true;
            Joueur = other.gameObject;
            other.GetComponentInChildren<ScriptMvtCamera>().enabled = false;
        }

    }

    private void TuerJoueur(float pourcentageFinOp)
    {
        Son.pitch = 0.8f/(pourcentageFinOp+1);
        //Joueur.GetComponentInChildren<Camera>().transform.Rotate(;
        Joueur.transform.GetComponentInChildren<Camera>().transform.LookAt(Vector3.Lerp(Joueur.transform.GetComponentInChildren<Camera>().transform.position - Joueur.transform.forward, this.transform.parent.Find("Tete").position, Mathf.Sqrt(temps)), Vector3.up);

        if (pourcentageFinOp >= 1)
        {
            joueurMort = false;
            foreach (AudioSource son in GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<AudioSource>())
            {
                son.pitch = 1;
            }
            Joueur.GetComponentInChildren<ScriptMvtCamera>().enabled = true;
            Joueur.transform.position = POSITIONLIT;
            Joueur.transform.GetComponentInChildren<Camera>().fieldOfView = 25;

            Joueur.transform.GetComponentInChildren<Camera>().transform.rotation = Quaternion.Euler(9.197f, Joueur.transform.rotation.eulerAngles.y, Joueur.transform.rotation.eulerAngles.z);
            Joueur = null;
            temps = 0;
        }
    }
}
