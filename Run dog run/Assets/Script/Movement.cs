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
    bool Starting = true;

    [Header("Movement + Gravity")]
    public float speed = 0f;
    private CharacterController controller;
    private float gravity = -9.81f;
    Vector3 YPos;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        animator.SetBool("Idle", true); //future: When button pressed to start set animation
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
        if (Starting)
        {
            ScoreText.text = "Press any key to start!";
        }
        else
        {
            Score = (int)controller.transform.position.z;
            ScoreText.text = Score.ToString();
        }
        //ChooseAnim(speed);
        if (Input.anyKeyDown && Score == 0)
        {
            Starting = false;
            animator.SetBool("Idle", false);
            animator.SetBool("isCantoring", true);
            speed = 5f;
        }
        if (Score%50 == 0 && Score!=0)
        {
            speed += 0.1f;
        }
    }

    //private void ChooseAnim(float x)
   // {
        //if (x >= 7.5) {
     //       animator.SetBool("isCantoring", true);
            //animator.SetBool("isRunning", true); Will renable when running animation looks less wonky 
        //}
    //}
}

