using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{
    public float speed;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = 1.0f;
           //transform.Rotate(0, 180, 0);
        }

        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "projectile")
        {
            this.gameObject.SetActive(false);
        }else if(collision.tag == "wall")
        {
            transform.Rotate(0, 180, 0);
        }
    }
}
