using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    private Vector2 targetPosition;

    [SerializeField]
    private Vector2 startPosition;

    [SerializeField]
    private Vector2 endPosition;

    [SerializeField]
    private float speed;

    private void Awake()
    {
        targetPosition = endPosition;
    }

    private void Update()
    {
        if ((Vector2)transform.position == targetPosition)
        {
            if (targetPosition == endPosition)
            {
                targetPosition = startPosition;
            }
            else
            {
                targetPosition = endPosition;
            }
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
