using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMover : MonoBehaviour
{
    // Start is called before the first frame update

    public float BoxSpeed = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        if(Math.Abs(pos.x) >= 15f) BoxSpeed *= (-1f);
        Vector2 new_pos = new Vector2(pos.x + BoxSpeed * Time.deltaTime, pos.y);
        transform.position = new_pos;
    }
}
