using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 acceleration;
    private Vector3 direction;

    public float mass = 1f;
    public bool bounceOffWalls = false;
    public bool useGravity = false;
    public bool useFriction = false;
    public float frictionCoeff = 0.2f;

    public Vector3 Velocity => velocity;
    public Vector3 Direction => direction;
    public Vector3 Position => transform.position;
    
    public Vector3 cameraSize;

    // Start is called before the first frame update
    void Start()
    {
        cameraSize.y = Camera.main.orthographicSize;
        cameraSize.x = cameraSize.y * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (useGravity)
        {
            ApplyGravity(Vector3.Scale(Vector3.down, Physics.gravity));
        }

        if (useFriction)
        {
            ApplyFriction(frictionCoeff);
        }


        // update physics
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        if (velocity.sqrMagnitude > Mathf.Epsilon) { direction = velocity.normalized; }

        acceleration = Vector3.zero;
        transform.rotation = Quaternion.LookRotation(Vector3.back, direction);

        if (bounceOffWalls) { BounceOffWalls(); }
    }

    // Applies a force to the object following Newton's second law of motion
    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    // Applies a friction force ot the object
    private void ApplyFriction(float coeff)
    {
        Vector3 friction = velocity * -1;
        friction.Normalize();
        friction *= coeff;

        ApplyForce(friction);
    }

    // Applies a gravitational force that acts on the object
    private void ApplyGravity(Vector3 gravityForce)
    {
        acceleration -= gravityForce;
    }

    // If off screen and still moving off screen, change direction of movement
    private void BounceOffWalls()
    {
        if (transform.position.x > cameraSize.x && velocity.x > 0)
        {
            velocity.x *= -1f;
        }
        
        if (transform.position.x < -cameraSize.x && velocity.x < 0)
        {
            velocity.x *= -1f;
        }
        
        if (transform.position.y > cameraSize.y && velocity.y > 0)
        {
            velocity.y *= -1f;
        }
        
        if (transform.position.y < -cameraSize.y && velocity.y < 0)
        {
            velocity.y *= -1f;
        }
    }
}
