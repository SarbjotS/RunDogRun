using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [Header("Animation + Camera")]
    private Animator animator;
    public Camera MyCamera;

    [Header("Score")]
    int Score = 0;
    public Text ScoreText; 

    [Header("Movement + Gravity")]
    public float speed = 5f;
    private CharacterController controller;
    private float gravity = -9.81f;
    Vector3 YPos;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        animator.SetBool("isCantoring", true); //future: When button pressed to start set animation
    }

    // Update is called once per frame
    void Update()
    {

        
        //Gravity
        if (!controller.isGrounded)
        {
            YPos.y += gravity * Time.deltaTime;
        }
        else
        {
            YPos.y = 0;
        }

        //Movement
        float horizontal = Input.GetAxisRaw("Horizontal");

        float DogSpeed = 1f;

        controller.Move(YPos * Time.deltaTime);

        Vector3 direction = new Vector3(horizontal, 0, 1f).normalized; //Put 0f on vertical

        if (direction.magnitude >= 0.1)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }

        //Score
        ScoreText.text = controller.transform.position.z.ToString("0") +"23";
        ChooseAnim(Score);

    }

    private void ChooseAnim(int x)
    {
        if (x >= 0 && x < 300) {
            animator.SetBool("isCantoring", true);
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isCantoring", false);
            animator.SetBool("isRunning", true);
        }
    }
}

