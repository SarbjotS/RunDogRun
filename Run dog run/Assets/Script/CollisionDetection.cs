using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public Movement mov;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Eat")
        {
            mov.FoodCount += 1;
        }
    }
}
