using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{

    SpriteRenderer myRenderer;
    public Color floorColor;
    public Color gateColor;

    public Rigidbody2D myBody;

    public float power;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        myBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            myBody.AddForce((Vector3.right) * power);
            //myBody.AddForce(new Vector3(1, 0, 0) * power);
        }
    }

    void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.name == "floor"){
            myRenderer.color = floorColor;
            Debug.Log("Hit floor");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "gate")
        {
            myRenderer.color = gateColor;
        }
    }
}