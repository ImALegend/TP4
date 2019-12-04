using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killScript : MonoBehaviour
{
    [SerializeField]
    GameObject DeathInstance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Kill()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("lutin") || collision.transform.parent.gameObject.name.Contains("lutin"))
        {
            for (int i = 0; i < 20; i++)
            {
                GameObject inst = Instantiate(DeathInstance, collision.transform, true);
                inst.GetComponentInChildren<Rigidbody>().AddForce(new Vector3(UnityEngine.Random.Range(-5, 5), 5, UnityEngine.Random.Range(-5, 5)));
            }
            
            Destroy(collision.gameObject);
            
        }

    }
}
