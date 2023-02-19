using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : MonoBehaviour
{
    Animator parentAnimator;

    private void Start() {
        parentAnimator = transform.parent.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Food") {
            parentAnimator.SetTrigger("FoundFruit");
        }
    }
}
