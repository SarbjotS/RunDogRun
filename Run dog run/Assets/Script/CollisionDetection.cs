using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Not used, keeping it just in case
public class CollisionDetection : MonoBehaviour
{
    public Movement mov;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Eat")
        {
            Debug.Log("Touched");
            Destroy(gameObject);
            mov.FoodCount += 1;
        }
    }
}
