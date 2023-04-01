using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleer : Agent
{
    public GameObject targetObj;

    protected override void CalculateSteeringForces()
    {
        if (targetObj)
        {
            Vector3 targetPos = targetObj.transform.position;
            targetPos.z = 0f;
            Flee(targetPos);
        }
    }
}
