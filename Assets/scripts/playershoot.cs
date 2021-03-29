using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershoot : MonoBehaviour
{

    public GameObject beam;
    public float shootSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBeam = Instantiate(beam, transform.position, transform.rotation);
            newBeam.transform.SetParent(gameObject.transform);
            newBeam.transform.localPosition = new Vector3(1.6f, 0.3f);
            float dir = 0;
            if (playerBehavior.faceRight)
            {
                dir = 1;
            }
            else
            {
                newBeam.GetComponent<SpriteRenderer>().flipX = true;
                dir = -1;
                newBeam.transform.localPosition = new Vector3(-1.6f, 0.3f);
            }
            newBeam.GetComponent<Rigidbody2D>().velocity = new Vector3(dir * shootSpeed, newBeam.transform.localPosition.y);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall")
        {
            Destroy(gameObject);

        }
    }
}