using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSeeker : Agent
{
    protected override void CalculateSteeringForces()
    {
        // seeking towards the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Seek(mousePos);
    }
}
