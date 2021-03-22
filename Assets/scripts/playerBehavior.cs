using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class playerBehavior : MonoBehaviour
{

    public GameObject respawn;
    //public GameObject fireball;

    public float speed = 5;
    public float jumpHeight = 8;

    Rigidbody2D myBody;
    BoxCollider2D myCollider;
    SpriteRenderer myRenderer;

    public Sprite jumpSprite;
    public Sprite walkSprite;

    float moveDir = 1;
    public bool onFloor = true;
    public static bool faceRight = true;

    public float yVel;

    public bool movelock;


    // Start is called before the first frame update
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
        myCollider = gameObject.GetComponent<BoxCollider2D>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();

        movelock = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        /*
        if(onFloor && myBody.velocity.y > 0){
            onFloor = false;
        }
        */

        yVel = myBody.velocity.y;

        if (movelock && Input.GetKeyDown(KeyCode.Q))
        {
           movelock = false;
        }

        CheckKeys();

        if (!movelock)
        {

        }

        HandleMovement();

       
    }
    void CheckKeys()
    {
        if (Input.GetKey(KeyCode.D))
        {
            moveDir = 1;
            faceRight = true;
            myRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveDir = -1;
            faceRight = false;
            myRenderer.flipX = true;
        }
        else
        {
            moveDir = 0;
        }

        if (Input.GetKey(KeyCode.W) && onFloor)
        {
            myRenderer.sprite = jumpSprite;
            myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);

            onFloor = false;
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //Instantiate(fireball, this.transform.position, this.transform.rotation);
        //}
    }

    void HandleMovement()
    {
        myBody.velocity = new Vector2(moveDir * speed, myBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "floor")
        {
            myRenderer.sprite = walkSprite;
            onFloor = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "door")
        {
            if (Input.GetKey(KeyCode.E))
            {
                other.gameObject.SetActive(false);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "enemy")
        {
            this.transform.position = respawn.transform.position;
        }

        if (collision.tag == "level end")
        {
            collision.gameObject.SetActive(false);
            SceneManager.LoadScene("level end");
        }
    }

}
