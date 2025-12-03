using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerWins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Win>())
        {
            Debug.Log("You win!");
        }
    }
}
