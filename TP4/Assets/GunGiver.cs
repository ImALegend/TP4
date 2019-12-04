using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGiver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<Press_Leftclick_to_Fire>().enabled = true;
            other.transform.Find("gun").gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
            other.transform.Find("gun").transform.Find("Handle").gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
            this.transform.parent.parent = null;

        }
    }
}
