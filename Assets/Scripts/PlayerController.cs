using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueForce = 1;
    [SerializeField] float boostSpeed = 30;
    [SerializeField] float normalSpeed = 20;

    bool canMove = true;
    SurfaceEffector2D surfaceEffector2D;
    Rigidbody2D rb2d;
    //float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            BoostPlayerSpeed();
        }
    }

    public void ForbidMoving()
    {
        canMove = false;
    }

    private void BoostPlayerSpeed()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueForce);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueForce);
        }
    }
}
