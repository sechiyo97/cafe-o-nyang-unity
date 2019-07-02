using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameDirector : MonoBehaviour {
    GameObject cat;
    SpriteRenderer catImage;
    int exitCountValue = 0;
    public int seatCnt = 9; // total available seat num
    public List<bool> isOccupied;
    public int emptySeatCnt;

    // Start is called before the first frame update
    void Start() {
        isOccupied = new List<bool>();
        for (int i = 0; i < seatCnt; i++) isOccupied.Add(false);
        emptySeatCnt = seatCnt;
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(emptySeatCnt);
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
