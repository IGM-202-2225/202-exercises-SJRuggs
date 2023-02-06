using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    private float radius;
    private float theta;
    public TextMesh textMesh;
    private TextMesh[] numbers;

    // Start is called before the first frame update
    void Start()
    {
        radius = 2.25f;
        numbers = new TextMesh[12];
        for (int i = 0; i < 12; i++)
        {
            theta = (i + 1) * Mathf.PI / 6;
            numbers[i] = Instantiate(textMesh, new Vector3(radius * Mathf.Sin(theta), radius * Mathf.Cos(theta), 1), Quaternion.identity);
            numbers[i].text = (i + 1) + "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
