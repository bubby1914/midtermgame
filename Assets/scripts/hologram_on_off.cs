using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hologram_on_off : MonoBehaviour
{

    public GameObject hologram;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            hologram.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            hologram.gameObject.SetActive(false);
        }
    }
}
