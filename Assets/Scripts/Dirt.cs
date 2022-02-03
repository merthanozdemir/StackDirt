using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dirt : MonoBehaviour
{

    private float Max_X=1.83f, Min_X=-1.83f;
    private bool canMove;
    private float moveSpeed = 3f;
    private Rigidbody2D body;
    private bool gameOver;
    private bool ignoreColl;
    private bool ignoreTrigg;
  
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = 0;
    }
    void Start()
    {
        canMove = true;
        Controller.instance.currentBox = this;
    }

    // Update is called once per frame
    void Update()
    {
        rightLeft();
    }
    void rightLeft() {

        if (canMove) {
            Vector2 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime;
            if (temp.x > Max_X) {

                moveSpeed = moveSpeed * -1f;

            }
            if (temp.x <Min_X)
            {

                moveSpeed = moveSpeed * -1f;

            }
            transform.position = temp;
           




        }
    }

    public void dropDirt() {
        canMove = false;
        body.gravityScale = 1;
    
    
    }

    void landed() {
        if (gameOver) {
            return; }
        else
        {
            ignoreColl = true;
            ignoreTrigg = true;
            Controller.instance.spawnNew();
            Controller.instance.moveCamera();
            scoreManager.instance.addScore();
            

        }
    
   
    }
    void restartGame()
    {
        Controller.instance.RestartGame();
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreColl)
        {
            return;
        }
        else {
            if (target.gameObject.tag == "platform") {

                Invoke("landed", 1f);
                ignoreColl = true;
            }
            if (target.gameObject.tag == "box")
            {

                Invoke("landed", 0.5f);
                ignoreColl = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "deadzone")
        {
            Debug.Log("yeniden baþlat");
            CancelInvoke("landed");
            ignoreTrigg = true;
            gameOver = true;
            Invoke("restartGame", 2f);
            


        }



    }
}
