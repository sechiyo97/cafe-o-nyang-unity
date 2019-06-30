using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catMove : MonoBehaviour {

    public bool drink = false;
    Animator animator;

    // Start is called before the first frame update
    void Start() {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (transform.position.x > 3) drink = true;

        if (drink) {
            Vector3 pos = transform.position;
            pos.x = 3.47f; pos.y = 0.05f;
            transform.position = pos;
            animator.SetTrigger("drinkTrigger");
        }
        else walkRight();
    }

    public void walkLeft() {
        transform.localScale = new Vector3( // left orientation
           0.5f,0.5f,1.0f);
        transform.Translate(new Vector2(-0.02f, -0.01f));
    }
    public void walkRight() {
        transform.localScale = new Vector3( // right orientation
           -0.5f, 0.5f, 1.0f);
        transform.Translate(new Vector2(0.02f, -0.01f));
    }
}
