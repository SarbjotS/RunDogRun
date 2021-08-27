using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    public Camera MyCamera;
    public float rotationSpeed = 15;
    float DesiredRotation = 0f;
    [SerializeField] public int Score = 0;

    public float speed = 5f;


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
        float horizontal = Input.GetAxisRaw("Horizontal"); //A and D key
                                                           // float vertical = Input.GetAxisRaw("Vertical"); //W and S Key
        float DogSpeed = 1f;                               //DogSpeed will increase as player keeps moving
        //DogSpeed = CalcSpeed(Score);
        ChooseAnim(Score);
        Vector3 direction = new Vector3(horizontal, 0f, 1f).normalized; //Put 0f on vertical

        if (direction.magnitude >= 0.1)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }
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

