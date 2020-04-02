using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    float speed = 500f;     // Ball's speed.

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
    }

    void Update() { }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Fix the rotation to match the direction of the camera's y axis.
        Vector3 fixedMovement = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * movement;

        rb.AddForce(fixedMovement * speed * Time.deltaTime);
    }
}
