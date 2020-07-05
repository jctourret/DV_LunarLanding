using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    RaycastHit downRay;

    float hSpeed;
    float vSpeed;
    float altitud;
    float fuel = 1000.0f;

    Rigidbody2D rb;
    Quaternion rotation;

    public float rocketProp = 1f;
    public float gravity = 0.16f;
    public float fuelConsumption = 1.0f;
    public float rotationSpeed = 100;
    public float currentRotation = 0;
    bool rocketOn;
    
    private void Start(){
        rocketOn = false;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update(){
        altitud = transform.position.y;
        hSpeed = rb.velocity.x;
        vSpeed = rb.velocity.x;
        rb.gravityScale = gravity;
        Debug.DrawRay(transform.position, Vector3.down, Color.yellow);

        if (Input.GetKey("space")){
            rocketOn = true;
        }
        else{
            rocketOn = false;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            currentRotation -= rotationSpeed * Time.deltaTime;
            rotation = Quaternion.Euler(new Vector3(0, 0, currentRotation));
            transform.rotation = rotation;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            currentRotation += rotationSpeed * Time.deltaTime;
            rotation = Quaternion.Euler(new Vector3(0, 0, currentRotation));
            transform.rotation = rotation;
        }
    }
    private void FixedUpdate(){
        if (rocketOn) {
            rb.AddRelativeForce(new Vector2(0, rocketProp));
            if (rb.velocity.x > 0) {
                rb.AddRelativeForce(new Vector2(-rocketProp/2, 0));
            }
            if (rb.velocity.x < 0)
            {
                rb.AddRelativeForce(new Vector2(+rocketProp/2, 0));
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Landing")
        {
        }
    }
}
