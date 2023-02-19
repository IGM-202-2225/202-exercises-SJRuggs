using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    SpriteRenderer r;
 
    // Start is called before the first frame update
    void Awake()
    {
        r = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        r.color = Color.red;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        r.color = Color.white;
    }
}
