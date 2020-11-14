using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GravityDirection : byte { Up, Down, Left, Right }

public class BaseChar : MonoBehaviour
{
    public Vector2 velocity;
    public Vector2 gravity = new Vector2(0, -1);



    // Start is called before the first frame update
    void Start()
    {
        velocity = gravity;
    }

    protected virtual void FixedUpdate()
    {
        transform.position += (Vector3)velocity;
    }
}
