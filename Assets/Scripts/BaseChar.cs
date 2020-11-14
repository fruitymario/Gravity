﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BaseChar : MonoBehaviour
{
    public enum GravityDirection : byte { Up, Down, Left, Right }

    public Vector2 velocity;
    public Vector2 gravity = new Vector2(0, -1);

    public static float gravitySpeed = 2;

    protected BoxCollider2D hitBox;

    protected virtual void Start()
    {
        velocity = gravity * gravitySpeed;

        hitBox = GetComponent<BoxCollider2D>();
    }

    protected virtual void FixedUpdate()
    {
        transform.position += (Vector3)velocity;
    }

    public void SetGravity(GravityDirection direction)
    {
        switch (direction)
        {
            case GravityDirection.Up:
                gravity = new Vector2(0, 1);
                break;
            case GravityDirection.Down:
                gravity = new Vector2(0, -1);
                break;
            case GravityDirection.Left:
                gravity = new Vector2(-1, 0);
                break;
            case GravityDirection.Right:
                gravity = new Vector2(1, 0);
                break;
            default:
                goto case GravityDirection.Down;
        }

        gravity *= gravitySpeed;
    }

    public void SetGravity(bool verticalGrav, bool negativeGrav)
    {
        if (verticalGrav) { gravity = (negativeGrav) ? new Vector2(0, -1) : new Vector2(0, 1); }
        else { gravity = (negativeGrav) ? new Vector2(-1, 0) : new Vector2(1, 0); }

        gravity *= gravitySpeed;
    }
}
