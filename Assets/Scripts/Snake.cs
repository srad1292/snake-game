using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField]
    SnakeSegment segmentPrefab;


    private Vector2 direction = new Vector2(0f, 0f);

    List<SnakeSegment> body = new List<SnakeSegment>();
    private bool shouldBodyMove = true;

    void Update()
    {
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && direction != Vector2.down ) {
            direction = Vector2.up;
            gameObject.transform.Rotate(0, 0, 90, Space.World);
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && direction != Vector2.up) {
            direction = Vector2.down;
            gameObject.transform.Rotate(0, 0, 270, Space.World);
        } else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && direction != Vector2.right) {
            direction = Vector2.left;
            gameObject.transform.Rotate(0, 0, 180, Space.World);
        } else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && direction != Vector2.left) {
            direction = Vector2.right;
            gameObject.transform.Rotate(0, 0, 0, Space.World);
        }
    }

    private void FixedUpdate() {
        float xPos = Mathf.Round(gameObject.transform.position.x + direction.x);
        float yPos = Mathf.Round(gameObject.transform.position.y + direction.y);



        if(shouldBodyMove) {
            for(int idx = body.Count-1; idx>=0; idx--) {
                if (idx == 0) {
                    body[idx].gameObject.transform.position = gameObject.transform.position;
                } else {
                    body[idx].gameObject.transform.position = body[idx - 1].gameObject.transform.position;
                }
            }
        }
        float zRotation = GetHeadRotation();
        Quaternion newRotation = gameObject.transform.rotation;
        newRotation.z = zRotation;
        gameObject.transform.SetPositionAndRotation(new Vector3(xPos, yPos, 0f), newRotation);
        if(shouldBodyMove == false) {
            foreach (SnakeSegment segment in body) {
                segment.shouldMove = true;
            }
            shouldBodyMove = true;
        }
    }

    private float GetHeadRotation() {
        if (direction == Vector2.up) { return 90f; }
        else if (direction == Vector2.down) { return 270f; }
        else if (direction == Vector2.left) { return 180f; }
        else { return 0f; }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Border" || other.tag == "Snake") {
            ResetGame();
        } else if(other.tag == "Food") {
            print("I ate some food!");
            SnakeSegment newSegment = Instantiate(segmentPrefab, gameObject.transform.position, Quaternion.identity);
            newSegment.direction = direction;
            newSegment.shouldMove = false;
            shouldBodyMove = false;
            if (body.Count == 0) {
                body.Add(newSegment);
            } else {
                body.Insert(0, newSegment);
                foreach(SnakeSegment segment in body) {
                    segment.shouldMove = false;
                }
            }
        }
    }

    private void ResetGame() {
        foreach (SnakeSegment segment in body) {
            Destroy(segment.gameObject);
        }
        body.Clear();
        direction = new Vector2(0f, 0f);
        gameObject.transform.SetPositionAndRotation(new Vector3(0f, 0f, 0f), Quaternion.identity);

    }


}
