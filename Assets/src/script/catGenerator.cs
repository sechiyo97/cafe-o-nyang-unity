using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catGenerator : MonoBehaviour {

    GameObject gameDirector;
    public GameObject[] catPrefab;
    float span = 5.0f; // time for new cat
    float delta = 0;

    // Start is called before the first frame update
    void Start() {
        this.gameDirector = GameObject.Find("gameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span && gameDirector.GetComponent<gameDirector>().emptySeatCnt > 0) {
            this.delta = 0;
            GameObject go = Instantiate(catPrefab[Random.Range(0,2)]) as GameObject;
            go.transform.position = new Vector3(1.6f, 2.2f, 0);
        }
    }
}
