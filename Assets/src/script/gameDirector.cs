using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameDirector : MonoBehaviour {
    GameObject catInfoPopup;
    SpriteRenderer catImage;
    int exitCountValue = 0;
    public int seatCnt = 9; // total available seat num
    public List<bool> isOccupied;
    public int emptySeatCnt;

    // to prevent clicking on multiple objects in a click
    public bool uiOpen = false;
    public bool uiClosedFlag = true; 

    // Start is called before the first frame update
    void Start() {
        // inactivate popups
        /* later...
        catInfoPopup = GameObject.Find("catInfoPopup");
        catInfoPopup.SetActive(false);
        */
        isOccupied = new List<bool>();
        for (int i = 0; i < seatCnt; i++) isOccupied.Add(false);
        emptySeatCnt = seatCnt;
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log(emptySeatCnt);

        // exit on two touch
        if (Input.GetKeyUp(KeyCode.Escape)) {
            exitCountValue++;
            if (!IsInvoking("disable_DoubleClick")) Invoke("disable_DoubleClick", 0.3f);
        }
        if (exitCountValue == 2) {
            CancelInvoke("disable_DoubleClick");
            Application.Quit();
        }

        // when click something
        if (Input.GetMouseButtonUp(0)) {
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero);

            float distance = Mathf.Infinity;

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, distance);

            //RaycastHit2D hitDrawer = Physics2D.Raycast(ray.origin, ray.direction, distance, 1 << LayerMask.NameToLayer("drawer"));
            //RaycastHit2D hitNPC = Physics2D.Raycast(ray.origin, ray.direction, distance, 1 << LayerMask.NameToLayer("npc"));
            //RaycastHit2D hitBubble = Physics2D.Raycast(ray.origin, ray.direction, distance, 1 << LayerMask.NameToLayer("bubble"));

            if (hit && !uiOpen) {
                Debug.Log(hit.collider.name);
                GameObject target = hit.collider.gameObject;

                // deprecated
                target.GetComponent<CatController>().infoPopup();
                uiOpen = true; uiClosedFlag = false;
                catInfoPopup.SetActive(true);
            } else if (uiClosedFlag) { uiOpen = false; }
        }
    }

    void disable_DoubleClick() {
        exitCountValue = 0;
    }
}
