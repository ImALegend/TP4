using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour
{

    public Transform target;
    public Transform cylinder;

    float cameraDistance = 50;

    void Start()
    {
    }

    void LateUpdate()
    {

        if (target)
        {

            // First, lets match the vertical position:    
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);

            //    Now find the direction of the Target from the cylinder.
            //    We Want to ignore the vertical position of each:
            Vector3 targetXZ = target.position;
            Vector3 cylinderXZ = cylinder.position;
            targetXZ.y = 0;
            cylinderXZ.y = 0;

            // Now find the direction:
            Vector3 targetDirection = (targetXZ - cylinderXZ).normalized;

            //Now we have the direction, we can find the position for the camera relative to the Target:
            transform.position = target.position + (targetDirection * cameraDistance); //Editted this line to fix mistake.

            //Now we just have to rotate it to look at the target:
            transform.LookAt(target);

        }
    }
}