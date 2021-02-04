using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{ 
    Rigidbody2D prb;
    [SerializeField] float speed;
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody2D projRB;
    int jumps = 0;
    int sceneNum = 0;
    string facing = "r";
    //int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        prb = GetComponent<Rigidbody2D>();
        //player = GetComponent<GameObject>();
    }


    // Update is called once per frame
    void Update()
    {
        rock();
        move();
    }

    bool checkJump() {
        if (jumps < 2) {
            jumps++;
            return true;
        }
        else if (Physics2D.Raycast(transform.position, Vector2.down, 0.3f))
        {
            jumps = 0;
            return true;
        }
        return false;
    }

    void rock() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D copy;
            copy = Instantiate(projRB, transform.position, transform.rotation);
          
            if (facing == "r") copy.AddForce(Vector2.right * 100);
            if (facing == "l") copy.AddForce(-Vector2.right * 100);
        }
    }
    void move() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            player.transform.localScale = new Vector3(-1, 1, 1);
            prb.velocity = new Vector2(-speed, prb.velocity.y);
            facing = "l";
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.localScale = new Vector3(1, 1, 1);
            prb.velocity = new Vector2(speed, prb.velocity.y);
            facing = "r";
        }else{
            prb.velocity = new Vector2(0, prb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && checkJump())
        {          
            prb.velocity = new Vector2(prb.velocity.x, speed + 1 );
        }
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Finish")){
            SceneManager.LoadScene(sceneName:"Nice");
        }
        else if (c.gameObject.CompareTag("enemy"))
        {
            transform.position = new Vector3(0, 0, 0);
        }
        else if (c.gameObject.CompareTag("Finish"))
        {
            sceneNum += 1;
            SceneManager.LoadScene(sceneNum);
        }
    }
}
