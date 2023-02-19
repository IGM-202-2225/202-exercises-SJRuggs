using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vehicle : MonoBehaviour
{
    // Controls
    VehicleControls controls;
    Vector2 move;
    float speed = 5f;

    // Direction
    Vector3 direction = new Vector3(0, 1, 0);

    // Wrapping
    float height;
    float width;
    float buffer = 0.5f;

    // Render
    SpriteRenderer r;

    // Start is called before the first frame update
    void Awake()
    {
        // Controls
        controls = new VehicleControls();
        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => move = Vector2.zero;

        // Wrapping
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
        height += buffer;
        width += buffer;

        // Render
        r = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Movement
        Vector3 movement = new Vector3(move.x, move.y, 0.0f) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Rotation
        if (move.x != 0 || move.y != 0)
        {
            direction = new Vector3(move.x, move.y, 0);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }

        // Wrapping
        if (transform.position.x > width) transform.position = new Vector3(-1.0f * width, transform.position.y, 0);
        if (transform.position.x < -1.0f * width) transform.position = new Vector3(width, transform.position.y, 0);
        if (transform.position.y > height) transform.position = new Vector3(transform.position.x, -1.0f * height, 0);
        if (transform.position.y < -1.0f * height) transform.position = new Vector3(transform.position.x, height, 0);
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
