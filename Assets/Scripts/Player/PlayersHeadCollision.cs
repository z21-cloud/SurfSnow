using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayersHeadCollision : MonoBehaviour
{
    [SerializeField] private float rayDistance = .1f;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private bool showDebugRays = true;

    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();

        if (boxCollider2D == null)
            Debug.LogError("BoxCollider2D не найден");
    }

    private void Update()
    {
        if(IsHeatingGround())
        {
            OnHeadHitGround();
        }
    }

    private bool IsHeatingGround()
    {
        Bounds bounds = boxCollider2D.bounds;

        Vector2 leftPointMax = new Vector2(bounds.min.x + 0.05f, bounds.max.y);
        Vector2 leftPointMin = new Vector2(bounds.min.x + 0.05f, bounds.min.y);
        Vector2 midPoint = new Vector2(bounds.center.x, bounds.max.y);
        Vector2 rightPointMax = new Vector2(bounds.max.x - 0.05f, bounds.max.y);
        Vector2 rightPointMin = new Vector2(bounds.max.x - 0.05f, bounds.min.y);

        Vector2 directionUp = Vector2.up;
        Vector2 directionLeft = Vector2.left;
        Vector2 directionRight = Vector2.right;

        bool leftHitUp = Physics2D.Raycast(leftPointMax, directionUp, rayDistance, groundLayer);
        bool leftHitLeftMax = Physics2D.Raycast(leftPointMax, directionLeft, rayDistance, groundLayer);
        bool leftHitLeftMin = Physics2D.Raycast(leftPointMin, directionLeft, rayDistance, groundLayer);
        
        bool midHitUp = Physics2D.Raycast(midPoint, directionUp, rayDistance, groundLayer);

        bool rightHitUp = Physics2D.Raycast(rightPointMax, directionUp, rayDistance, groundLayer);
        bool rightHitRightMax = Physics2D.Raycast(rightPointMax, directionRight, rayDistance, groundLayer);
        bool rightHitRightMin = Physics2D.Raycast(rightPointMin, directionRight, rayDistance, groundLayer);

        if(showDebugRays)
        {
            Debug.DrawRay(leftPointMax, directionUp * rayDistance,     Color.red); //leftHitUp ? Color.red : Color.green); // max up left
            Debug.DrawRay(leftPointMax, directionLeft * rayDistance,   Color.red); //leftHitLeftMax ? Color.red : Color.green); // max left
            Debug.DrawRay(leftPointMin, directionLeft * rayDistance,   Color.red); //leftHitLeftMin ? Color.red : Color.green); // min left
            Debug.DrawRay(midPoint, directionUp * rayDistance,         Color.red); //midHitUp ? Color.red : Color.green); // mid up
            Debug.DrawRay(rightPointMax, directionUp * rayDistance,    Color.red); //rightHitUp ? Color.red : Color.green); ///max up right
            Debug.DrawRay(rightPointMax, directionRight * rayDistance, Color.red); //rightHitRightMax ? Color.red : Color.green); ///max right
            Debug.DrawRay(rightPointMin, directionRight * rayDistance, Color.red); //rightHitRightMin ? Color.red : Color.green); //min right
        }

        return midHitUp || rightHitUp || rightHitRightMax || rightHitRightMin || leftHitUp || leftHitLeftMax || leftHitLeftMin;
    }

    private void OnHeadHitGround()
    {
        Debug.Log("You loss");
    }
}
