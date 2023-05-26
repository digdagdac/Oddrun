using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollisionHandler : MonoBehaviour
{
    public static bool gameover;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Collision with the player detected
            // Add your collision handling code here
            Debug.Log("È÷È÷1");
            gameover = true;
        }
    }
    


}
