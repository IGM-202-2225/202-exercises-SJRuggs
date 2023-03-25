using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject bluePrefab;
    public GameObject greenPrefab;
    public GameObject redPrefab;
    public Vector3 mousePosition;
    
    private Vector3 velocity;
    private Vector3 acceleration;
    private List<PhysicsObject> monsters;
    
    // Start is called before the first frame update
    void Start()
    {
        monsters = new List<PhysicsObject>();
        monsters.Add(Instantiate(bluePrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<PhysicsObject>());
        monsters.Add(Instantiate(redPrefab, new Vector3(-5f, 0, 0), Quaternion.identity).GetComponent<PhysicsObject>());
        monsters.Add(Instantiate(greenPrefab, new Vector3(5f, 0, 0), Quaternion.identity).GetComponent<PhysicsObject>());
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        foreach (PhysicsObject monster in monsters)
        {
            Vector3 diff = mousePosition - monster.transform.position;
            diff.z = 0;
            monster.ApplyForce(diff);
        }
    }
}
