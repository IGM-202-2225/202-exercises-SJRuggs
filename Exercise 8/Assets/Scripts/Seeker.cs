using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    public GameObject targetObj;

    protected override void CalculateSteeringForces()
    {
        if (targetObj)
        {
            Vector3 targetPos = targetObj.transform.position;
            targetPos.z = 0f;
            Seek(targetPos);
            if (Vector3.Distance(targetPos, transform.position) <= 0.5)
            {
                targetObj.transform.position = new Vector3(
                    Random.Range(-1 * physicsObject.cameraSize.x, physicsObject.cameraSize.x),
                    Random.Range(-1 * physicsObject.cameraSize.y, physicsObject.cameraSize.y));
            }
        }
    }
}
