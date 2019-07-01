using UnityEngine;

public class catMove : MonoBehaviour {
    float[,] chairOnPos
        = { { 3.78f, -0.44f }, { 1.84f, -1.45f }, { 0.12f, -2.44f }, { -1.8f, -1.38f }
        , { -3.84f, -0.81f }, { -1.91f, 0.3f }, { -0.5f, -0.37f }, { 1.26f, -0.37f } , { 1.45f, 0.72f }
        , { -3.95f, 2.33f }, { -5.85f, 3.41f }, { -2.04f, 3.49f }, { -3.9f, 4.57f }  }; // 수정 필요
    float[,] chairOffPos
        = { { 2.98f, -0.31f }, { 1.84f, -1.45f }, { 0.12f, -2.44f }, { -1.8f, -1.38f }
        , { -3.84f, -0.81f }, { -1.91f, 0.3f }, { -0.5f, -0.37f }, { 1.26f, -0.37f } , { 1.45f, 0.72f }
        , { -3.95f, 2.33f }, { -5.85f, 3.41f }, { -2.04f, 3.49f }, { -3.9f, 4.57f }  }; // 수정 필요ssssssssssssssssssssssssssssssssssssssssssssssssssssss
    int[] chairType
        = { 1, 3, 4, 2, 3, 1, 3, 4, 1, 4, 2, 4, 2 };
    int[] catLayer
        = {25,29,39,35, 9,5,19,19,15,17,13,7,3};
    int chairNum;

    // 4 status of cat: coming, waiting, eating, going
    public int status = 1;

    bool arrive = false;
    bool forward = true;
    Animator animator;
    GameObject gameDirector;
    new SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start() {
        this.gameDirector = GameObject.Find("gameDirector");
        this.animator = GetComponent<Animator>();
        this.renderer = GetComponent<SpriteRenderer>();
        this.chairNum = 1;// Random.Range(1,9);
        while(gameDirector.GetComponent<gameDirector>().isOccupied[chairNum] == true) this.chairNum = Random.Range(1,9);
        gameDirector.GetComponent<gameDirector>().isOccupied[chairNum] = true;
    }

    // Update is called once per frame
    void Update() {
        switch (status) {
            case 1: coming(); break;
            case 2: waiting(); break;
            case 3: eating(); break;
            case 4: going(); break;
        }
    }

    // coming to a seat
    void coming() {
        if (arrive) { // if sit down, go to next state(2, waiting)
            switch (chairType[chairNum - 1]) {
                case 1:
                    animator.SetTrigger("drink_front");
                    renderer.flipX = false;
                    break;
                case 2:
                    animator.SetTrigger("drink_front");
                    renderer.flipX = true;
                    break;
                case 3:
                    animator.SetTrigger("drink_back");
                    renderer.flipX = false;
                    break;
                case 4:
                    renderer.flipX = true;
                    animator.SetTrigger("drink_back");
                    break;
            }
            sitDown(1.0f, catLayer[chairNum - 1]);
            Invoke("startWaiting", 0);
            return;
        } else { // else, move to a seat
            switch (chairNum) { // start pos = 1.6, 2.2
                case 1:
                    if (transform.position.y > 1.5f) walk(1, -1, 0);
                    else if (transform.position.y > -0.1f) walk(1, 1, 2);
                    else if (transform.position.y > -0.4f) walk(1, -1, 21);
                    else if (transform.position.y > -0.5f) walk(1, 1, 21);
                    else arrive = true;
                    break;
                case 2:
                    if (transform.position.y > 1.5f) walk(1, -1, 0);
                    else if (transform.position.y > -0.2f) walk(1, 1, 2);
                    else if (transform.position.y > -1.4f) walk(1, -1, 21);
                    else if (transform.position.y > -1.5f) walk(1, 1, 21);
                    else arrive = true;
                    break;
                case 3:
                    if (transform.position.y > 1.5f) walk(1, -1, 0);
                    else if (transform.position.y > -0.2f) walk(1, 1, 2);
                    else if (transform.position.y > -1.9f) walk(1, -1, 21);
                    else if (transform.position.y > -2.2f) walk(1, 1, 31);
                    else if (transform.position.y > -2.3f) walk(1, -1, 31);
                    else arrive = true;
                    break;
                case 4:
                    if (transform.position.y > 0.6f) walk(1, -1, 0);
                    else if (transform.position.y > 0f) walk(1, 1, 2);
                    else if (transform.position.y > -0.6f) walk(1, -1, 11);
                    else if (transform.position.y > -1.2f) walk(1, 1, 31);
                    else if (transform.position.y > -1.3f) walk(1, -1, 31);
                    else arrive = true;
                    break;
                case 5:
                    if (forward) {
                        if (transform.position.y > 0.5f) walk(1, -1, 0);
                        else if (transform.position.y > -0.1f) walk(1, 1, 2);
                        else if (transform.position.y > -0.7f) walk(1, -1, 11);
                        else if (transform.position.y > -0.9f) walk(1, 1, 21);
                        else if (transform.position.y > -1.6f) walk(1, -1, 21);
                        else forward = false;
                    } else if (transform.position.y < -1.5f) walk(-1, -1, 11);
                    else arrive = true;
                    break;
                case 6:
                    if (forward) {
                        if (transform.position.y > 0.5f) walk(1, -1, 0);
                        else if (transform.position.y > -0.1f) walk(1, 1, 2);
                        else if (transform.position.y > -0.5f) walk(1, -1, 11);
                        else forward = false;
                    } else if (transform.position.y < -0.4f) walk(-1, -1, 11);
                    else arrive = true;
                    break;
                case 7:
                    if (transform.position.y > 0.5f) walk(1, -1, 0);
                    else if (transform.position.y > 0f) walk(1, 1, 2);
                    else if (transform.position.y > -0.2f) walk(1, -1, 2);
                    else if (transform.position.y > -0.3f) walk(1, 1, 2);
                    else arrive = true;
                    break;
                case 8:
                    if (transform.position.y > 1.5f) walk(1, -1, 0);
                    else if (transform.position.y > 0.2f) walk(1, 1, 2);
                    else if (transform.position.y > -0.4f) walk(1, -1, 15);
                    else arrive = true;
                    break;
                case 9:
                    if (transform.position.y > 1.1f) walk(1, -1, 2);
                    else if (transform.position.y > 0.7f) walk(1, 1, 2);
                    else arrive = true;
                    break;
                default:
                    if (transform.position.y > -0.2f) walk(1, 1, 2);
                    else arrive = true;
                    break;
            }
        } 
    }
    void waiting() {
        Invoke("startEating", 3); // 2초뒤 LaunchProjectile함수 호출
    }
    void eating() {
        Invoke("startGoing", 3); // 2초뒤 LaunchProjectile함수 호출
    }
    void going() {
        if (arrive) { standUp(1.0f, catLayer[chairNum - 1]); arrive = false; }
        else{
            switch (chairNum) { // start pos = each chair, end pos = 1.6, 2.2
                case 1:
                    if (transform.position.y < -0.5f) walk(-1, -1, 21);
                    else if (transform.position.y < -0.4f) walk(-1, -1, 21);
                    else if (transform.position.y < -0.1f) walk(-1, 1, 2);
                    else if (transform.position.y < 1.5f) walk(-1, -1, 2);
                    else if (transform.position.y < 2.2f) walk(-1, 1, 0);
                    else Invoke("gone", 0);
                    break;
                case 2:
                    if (transform.position.y > 1.5f) walk(1, -1, 0);
                    else if (transform.position.y > -0.2f) walk(1, 1, 2);
                    else if (transform.position.y > -1.4f) walk(1, -1, 21);
                    else if (transform.position.y > -1.5f) walk(1, 1, 21);
                    else Invoke("gone", 0);
                    break;
                case 3:
                    if (transform.position.y > 1.5f) walk(1, -1, 0);
                    else if (transform.position.y > -0.2f) walk(1, 1, 2);
                    else if (transform.position.y > -1.9f) walk(1, -1, 21);
                    else if (transform.position.y > -2.2f) walk(1, 1, 31);
                    else if (transform.position.y > -2.3f) walk(1, -1, 31);
                    else Invoke("gone", 0);
                    break;
                case 4:
                    if (transform.position.y > 0.6f) walk(1, -1, 0);
                    else if (transform.position.y > 0f) walk(1, 1, 2);
                    else if (transform.position.y > -0.6f) walk(1, -1, 11);
                    else if (transform.position.y > -1.2f) walk(1, 1, 31);
                    else if (transform.position.y > -1.3f) walk(1, -1, 31);
                    else Invoke("gone", 0);
                    break;
                case 5:
                    if (forward) {
                        if (transform.position.y > 0.5f) walk(1, -1, 0);
                        else if (transform.position.y > -0.1f) walk(1, 1, 2);
                        else if (transform.position.y > -0.7f) walk(1, -1, 11);
                        else if (transform.position.y > -0.9f) walk(1, 1, 21);
                        else if (transform.position.y > -1.6f) walk(1, -1, 21);
                        else forward = false;
                    } else if (transform.position.y < -1.5f) walk(-1, -1, 11);
                    else Invoke("gone", 0);
                    break;
                case 6:
                    if (forward) {
                        if (transform.position.y > 0.5f) walk(1, -1, 0);
                        else if (transform.position.y > -0.1f) walk(1, 1, 2);
                        else if (transform.position.y > -0.5f) walk(1, -1, 11);
                        else forward = false;
                    } else if (transform.position.y < -0.4f) walk(-1, -1, 11);
                    else Invoke("gone", 0);
                    break;
                case 7:
                    if (transform.position.y > 0.5f) walk(1, -1, 0);
                    else if (transform.position.y > 0f) walk(1, 1, 2);
                    else if (transform.position.y > -0.2f) walk(1, -1, 2);
                    else if (transform.position.y > -0.3f) walk(1, 1, 2);
                    else Invoke("gone", 0);
                    break;
                case 8:
                    if (transform.position.y > 1.5f) walk(1, -1, 0);
                    else if (transform.position.y > 0.2f) walk(1, 1, 2);
                    else if (transform.position.y > -0.4f) walk(1, -1, 15);
                    else Invoke("gone", 0);
                    break;
                case 9:
                    if (transform.position.y > 1.1f) walk(1, -1, 0);
                    else if (transform.position.y > 0.7f) walk(1, 1, 2);
                    else Invoke("gone", 0);
                    break;
                default:
                    if (transform.position.y > -0.2f) walk(1, 1, 2);
                    else Invoke("gone", 0);
                    break;
            }
        }
    }

    public void walk(int face, int orientation, int layer) { // front/back, right/left
        if (face < 0) animator.SetTrigger("walk_back");
        renderer.sortingOrder = layer;
        renderer.flipX = orientation>0?true: false;
        transform.Translate(new Vector2(orientation*0.01f, -face*0.005f));
    }
    public void sitDown(float orientation, int layer) { // left = -1, right = 1
        renderer.sortingOrder = layer;
        Vector3 pos = transform.position;
        pos.x = chairOnPos[chairNum - 1, 0]; pos.y = chairOnPos[chairNum - 1, 1];
        transform.position = pos;
    }
    public void standUp(float orientation, int layer) { // left = -1, right = 1
        renderer.sortingOrder = layer;
        Vector3 pos = transform.position;
        pos.x = chairOffPos[chairNum - 1, 0]; pos.y = chairOffPos[chairNum - 1, 1];
        transform.position = pos;
    }
    public void startWaiting() { status = 2; }
    public void startEating() { status = 3; }
    public void startGoing() {
        status = 4;
        animator.SetTrigger("walk_back");
    }
    public void gone() { Debug.Log("gone!"); }
}
