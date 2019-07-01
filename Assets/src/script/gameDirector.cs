using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameDirector : MonoBehaviour
{
    GameObject cat;
    SpriteRenderer catImage;
    int exitCountValue = 0;
    public bool[] isOccupied = { false, false, false, false, false, false, false, false, false, false, false, false, false };

    // Start is called before the first frame update
    void Start() {
        cat = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            exitCountValue++;
            if (!IsInvoking("disable_DoubleClick")) Invoke("disable_DoubleClick", 0.3f);
        }
        if (exitCountValue == 2) {
            CancelInvoke("disable_DoubleClick");
            Application.Quit();
        }
    }
    void disable_DoubleClick() {
        exitCountValue = 0;
    }
}
