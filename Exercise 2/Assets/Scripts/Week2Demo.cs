using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2Demo : MonoBehaviour
{
    [SerializeField]
    int someNum = 5;
    public GameObject flowerManPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i > someNum; i++)
        {
            // Create copy
            Instantiate(flowerManPrefab, new Vector3(i * 20, 0, 0), new Quaternion());
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(someNum);
    }
}
