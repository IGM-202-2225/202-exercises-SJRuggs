using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{

    // the amount to turn the hand every frame in degrees
    private float turnAmount;

    // toggles between uysing Time.deltaTime and not
    public bool useDeltaTime;

    // Start is called before the first frame update
    void Start()
    {
        turnAmount = 2 * Mathf.PI;
    }

    // Update is called once per frame
    void Update()
    {
        if (useDeltaTime)
        {
            gameObject.transform.Rotate(0.0f, 0.0f, -1 * turnAmount * Time.deltaTime, Space.Self);
        }
        else
        {
            gameObject.transform.Rotate(0.0f, 0.0f, -1 * turnAmount, Space.Self);
        }
    }
}
