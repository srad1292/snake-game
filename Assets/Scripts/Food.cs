using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    [SerializeField]
    BoxCollider2D foodSpawn;

    // Start is called before the first frame update
    void Start()
    {
        MoveFood();
        gameObject.SetActive(true);
        print("Min x: " + foodSpawn.bounds.min.x.ToString());
        print($"Max x: " + foodSpawn.bounds.max.x.ToString());
        print($"Min y: " + foodSpawn.bounds.min.y.ToString());
        print($"Max y: " + foodSpawn.bounds.max.y.ToString());
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Snake") {
            MoveFood();
        }

    }

    private void MoveFood() {
        float xPos = Mathf.Round(Random.Range(foodSpawn.bounds.min.x, foodSpawn.bounds.max.x));
        float yPos = Mathf.Round(Random.Range(foodSpawn.bounds.min.y, foodSpawn.bounds.max.y));

        gameObject.transform.SetPositionAndRotation(new Vector3(xPos, yPos, 0f), Quaternion.identity);
    }
}
