using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTriggerFood : MonoBehaviour
{

    public Movement mv;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Eat" )
        {
            mv.FoodCount += 1;
            Destroy(other.gameObject);
        }else if (other.tag == "Avoid")
        {
            mv.GameOverManGameOver.text = "Game Over! Press + to restart, - to return to the menu";
            mv.speed = 0;
            
        }

        //if (other.tag == "Avoid" && other.tag != "Eat") { }
        //mv.GameOverManGameOver.text = "Game Over! Press + to restart, - to return to the menu";
        //mv.speed = 0;
    }

}

