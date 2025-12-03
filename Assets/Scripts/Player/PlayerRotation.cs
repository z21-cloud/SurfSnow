using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    //[SerializeField] private Collider2D lossCondition;
    //[SerializeField] private LayerMask layer;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if(rb == null)
        {
            Debug.LogError("RigidBody2D is null!");
        }
    }

    private void Update()
    {
        Vector2 input = InputManager.Instance.GetInput();
        
        if(input != null) RotatePlayer(input);
    }

    private void RotatePlayer(Vector2 input)
    {
        Debug.Log(input.x);
        rb.AddTorque(rotationSpeed * (-input.x)); //minus, because i want to player rotates to left if he hits left and right if he hits right. Without minus I've got opposite direction
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(lossCondition.IsTouchingLayers(layer))
        {
            Debug.Log("You loss");
        }
    }*/
}
