using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catMove : MonoBehaviour {

    public bool drink = false;
    public bool walking = true;
    Animator animator;
    int chairNum = 1;

    // Start is called before the first frame update
    void Start() {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        if (drink && walking) {
            walking = false;
            animator.SetTrigger("drink_back_trig");
        } else if (walking) {
            if (transform.position.y > -0.2) walk(1.0f, 0);
            else if (transform.position.y > -1.1) walk(-1.0f, 29);
            else if (transform.position.y > -1.3) walk(1.0f, 29);
            else drink = true;
        } else {
            sitDown(1.0f, 37);
        }
    }

    public void walk(float orientation, int layer) { // left = -1, right = 1
        GetComponent<SpriteRenderer>().sortingOrder = layer;
        transform.localScale = new Vector3( // left orientation
           -orientation*0.5f,0.5f,1.0f);
        transform.Translate(new Vector2(orientation*0.02f, -0.01f));
    }
    public void sitDown(float orientation, int layer) { // left = -1, right = 1
        GetComponent<SpriteRenderer>().sortingOrder = layer;
        Vector3 pos = transform.position;
        //pos.x = 3.7f; pos.y = -0.3f;
        pos.x = 1.84f; pos.y = -1.45f;
        transform.position = pos;
        transform.localScale = new Vector3( // left orientation
           orientation*0.5f, 0.5f, 1.0f);
    }
}
