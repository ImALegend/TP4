using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTest : MonoBehaviour
{
    [SerializeField]
    Transform teleportTarget;
    [SerializeField]
    GameObject thePlayer;

    void OnTriggerStay(Collider other)
    {
        if(other.name == "FirstPersonCharacter")
            thePlayer.transform.position = teleportTarget.transform.position;
    }
}
