using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    private Vector3 playerVelocity;
    private bool GroundedDog;
    private bool Walking;
    private float DogSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    [SerializeField] private float rotationSpeed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // if (controller.isGrounded && playerVelocity.y < 0) //If player starts going up, put him back down
        //  {
        //      playerVelocity.y = 0f;
        // }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Walking = Input.GetKey(KeyCode.LeftShift);
       // Vector3 movement = new Vector3(x, 0, z).normalized;
        
        Vector3 move = transform.forward * DogSpeed * Input.GetAxisRaw("Vertical");
        controller.Move(move * Time.deltaTime * DogSpeed);

        transform.Rotate(Vector3.up * Input.GetAxisRaw("Horizontal") * rotationSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);



        animator.SetBool("Walk", Input.GetAxisRaw("Vertical") != 0);
    }
}
