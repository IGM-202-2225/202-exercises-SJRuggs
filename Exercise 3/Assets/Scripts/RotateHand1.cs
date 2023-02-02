using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHandHour : MonoBehaviour
{
    public GameObject hand;

    // the amount to turn the hand every frame in degrees
    private float turnAmount;

    // toggles between uysing Time.deltaTime and not
    private bool useDeltaTime;

    // Start is called before the first frame update
    void Start()
    {
        turnAmount = Mathf.PI;
        useDeltaTime = false;
        hand = GameObject.Find("minutehand");
    }

    // Update is called once per frame
    void Update()
    {
        if (useDeltaTime)
        {
            hand.transform.Rotate(0.0f, 0.0f, -1 * turnAmount * Time.deltaTime, Space.Self);
        }
        else
        {
            hand.transform.Rotate(0.0f, 0.0f, -1 * turnAmount, Space.Self);
        }
    }
}
