using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipe : MonoBehaviour {

    const int MAX_X = 5;
    const int MIN_X = -5;
    const int MAX_Y = 5;
    const int MIN_Y = -5;
    const float fscale = 0.01f;

    Vector2 vscale = new Vector2(fscale, fscale);
    Vector2 startPos;
    Vector2 curPos;
    Vector2 change;
    bool hold = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            this.hold = true;
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0)) {
            this.hold = false;
        }
        if (this.hold) {
            this.curPos = Input.mousePosition;
            transform.Translate(vscale * (startPos - curPos));
            if (outside()) transform.Translate(vscale*(curPos-startPos));
            startPos = curPos;
        }
    }
    bool outside() {
        if (transform.position.x > MAX_X || transform.position.x < MIN_X
            || transform.position.y > MAX_Y || transform.position.y < MIN_Y)
            return true;
        else return false;
    }
}
