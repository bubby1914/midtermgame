using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timed_shoot : MonoBehaviour
{
    public float timerSet;
    float timer;

    public GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        timer = timerSet;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = timerSet;
            Instantiate(laser, this.transform.position, this.transform.rotation); 
        }
    }
}
