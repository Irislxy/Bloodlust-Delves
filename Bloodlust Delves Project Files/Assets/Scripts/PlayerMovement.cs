using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float jumpHeight = 3f;

    public float dragCoefficient = 0.05f;
    public float frictionCoefficient = 50f;

    bool isGrounded;

    Vector3 velocity;

    private Vector3 outsideForces;
 
     //You can adjust this
     public float forceDecayRate = 1f;
 
     public void AddForce(Vector3 force){
         outsideForces += force;
     }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey ("escape")) {
                 Application.Quit();
        }


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        outsideForces = Vector3.Lerp(outsideForces, Vector3.zero, forceDecayRate*Time.deltaTime);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButton("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        velocity += outsideForces * Time.deltaTime;

        Vector3 dragForce = - dragCoefficient * Vector3.Scale(velocity.normalized, new Vector3(velocity.x * velocity.x, velocity.y * velocity.y, velocity.z * velocity.z));

        Vector3 frictionForce = - frictionCoefficient * new Vector3(velocity.x, 0, velocity.z).normalized;

        velocity += (dragForce + frictionForce) * Time.deltaTime;


        controller.Move(velocity * Time.deltaTime);
    }

    
}
