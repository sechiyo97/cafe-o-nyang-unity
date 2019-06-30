using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameDirector : MonoBehaviour
{
    GameObject cat;
    SpriteRenderer catImage;

    // Start is called before the first frame update
    void Start() {
        cat = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update() {
    }
}
