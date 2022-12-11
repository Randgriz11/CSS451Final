using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    // Distance to move the ball left and right
    public float distance = 5.0f;

    // Time interval for moving the ball
    public float interval = 1.0f;

    // Flag to indicate whether the ball is currently moving left or right
    private bool isMovingLeft = false;

    void Start()
    {
        // Start moving the ball left and right
        StartCoroutine(MoveBall());
    }

    IEnumerator MoveBall()
    {
        while (true)
        {
            // Calculate the direction and distance to move the ball
            Vector3 direction = isMovingLeft ? Vector3.left : Vector3.right;
            Vector3 distanceVector = direction * distance;

            // Calculate the new position of the ball
            Vector3 startPosition = transform.position;
            Vector3 endPosition = startPosition + distanceVector;

            // Move the ball from the start position to the end position over the given time interval
            float startTime = Time.time;
            while (Time.time < startTime + interval)
            {
                float t = (Time.time - startTime) / interval;
                transform.position = Vector3.Lerp(startPosition, endPosition, t);
                yield return null;
            }

            // Update the direction of the ball movement
            isMovingLeft = !isMovingLeft;
        }
    }
}