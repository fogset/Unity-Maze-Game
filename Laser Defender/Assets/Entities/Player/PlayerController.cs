﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;
    public float padding = 0.5f;
    // Use this for initialization
    float xmin;
    float xmax;
    float ymin, ymax;
    public GameObject projectile;
    public float projectileSpeed;
    public float firingRate=0.2f;

    void Start()
    {
        
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost =Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        Vector3 topleft = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));
        //restrict the x position
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
        //restrict the y position
        ymin = leftmost.y + padding;
        ymax = topleft.y - padding;
    }
    void Fire()
    {
        GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
    }
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, firingRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }
         
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //old version transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        //restrict the player to the gamespace
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        float newY = Mathf.Clamp(transform.position.y, ymin, ymax);
        transform.position = new Vector3(newX, newY, transform.position.z);

    }
}


 
