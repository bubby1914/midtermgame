using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_activator : MonoBehaviour
{
    public string animName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.parent.GetComponent<Animation>().Play(animName);
            Destroy(gameObject);
        }
    }
}
