using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    [Header("Animation + Camera")]
    private Animator animator;
    public Camera MyCamera;

    [Header("Score")]
    public int Score = 0;
    public int FoodCount = 0;

    bool Starting = true;

    [Header("Movement + Gravity")]
    public float speed = 0f;
    private CharacterController controller;
    private float gravity = -9.81f;
    Vector3 YPos;

    [Header("Text")]
    public Text ScoreText;
    public Text FoodText;
    public Text GameOverManGameOver;
    // private void OnCollisionEnter(Collision collision)
    // {
    //   if (collision.collider.tag == "Eat")
    //  {
    //     Debug.Log("touched");
    //    FoodCount += 1;
    // }
    // }
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
            FoodText.text = "Collect food, avoid everything else!";
            GameOverManGameOver.text = "";
            animator.SetBool("Idle", true);

        }
        else
        {
            Score = (int)controller.transform.position.z;
            ScoreText.text = Score.ToString();
            FoodText.text = "Eaten: " + FoodCount;
            animator.SetBool("isCantoring", true);

        }
        //ChooseAnim(speed);
        if (Input.anyKeyDown && Score == 0)
        {
            Starting = false;
            animator.SetBool("Idle", false);
            speed = 5f;
        }
        if (Score%50 == 0 && Score!=0)
        {
            speed += 0.1f;
        }

        if(speed == 0 && !Starting)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("isCantoring", false);

        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

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

