using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float smoothTime = .15f;
    [SerializeField] private Vector2 offset = new Vector2(1, 0);

    private Transform player;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        if (player == null) player = PlayerLocator.Player.transform;
        Vector3 newPos = new Vector3(player.position.x + offset.x, player.position.y + offset.y, -10);
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothTime);
    }
}
