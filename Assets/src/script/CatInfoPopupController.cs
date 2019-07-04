using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInfoPopupController : MonoBehaviour
{
    GameObject gameDirector;

    public void Start() {
        gameDirector = GameObject.Find("gameDirector");
    }

    public void Update() {
    }

    public void exit() {
        gameDirector.GetComponent<gameDirector>().uiClosedFlag = true;
        gameObject.SetActive(false);
    }
}
