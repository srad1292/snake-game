using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSegment : MonoBehaviour
{
    public Vector2 direction { get; set; }

    public bool shouldMove { get; set; }

    /*private void FixedUpdate() {
        if (!shouldMove) return;

        float xPos = Mathf.Round(gameObject.transform.position.x + direction.x);
        float yPos = Mathf.Round(gameObject.transform.position.y + direction.y);

        gameObject.transform.SetPositionAndRotation(new Vector3(xPos, yPos, 0f), Quaternion.identity);
    }*/
}
