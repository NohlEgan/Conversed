using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMovement : MonoBehaviour
{
    private Vector2 targetPosition;
    
    private Vector2 startPosition;
    private Vector2 endPosition;

    [SerializeField]
    private float speed;

    private void Awake()
    {
        startPosition = transform.position;
        endPosition = startPosition;
        endPosition.y += 0.5f;

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
