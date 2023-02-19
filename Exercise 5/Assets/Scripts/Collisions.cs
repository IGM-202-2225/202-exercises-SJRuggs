using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collisions : MonoBehaviour
{
    BoundingControls controls;
    bool toggle;
    TextMeshProUGUI text;
    GameObject vehicle;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new BoundingControls();
        controls.Bounding.Toggle.performed += ctx => Toggle();
        text = GameObject.Find("Canvas/CurrentColliderText").GetComponent<TMPro.TextMeshProUGUI>();
        toggle = true;
        vehicle = GameObject.Find("vehicle");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnEnable()
    {
        controls.Bounding.Enable();
    }

    private void OnDisable()
    {
        controls.Bounding.Disable();
    }

    void Toggle()
    {
        if (toggle)
        {
            text.text = "Current Collider Shape: Circle";
            vehicle.GetComponent<BoxCollider2D>().enabled = false;
            vehicle.GetComponent<CircleCollider2D>().enabled = true;
        }
        else
        {
            text.text = "Current Collider Shape: Square";
            vehicle.GetComponent<BoxCollider2D>().enabled = true;
            vehicle.GetComponent<CircleCollider2D>().enabled = false;
        }
        toggle = !toggle;
    }
}
