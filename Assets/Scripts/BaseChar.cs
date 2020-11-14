using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseChar : MonoBehaviour
{
    public enum GravityDirection : byte { Up, Down, Left, Right }

    public Vector2 velocity;
    public Vector2 gravity = new Vector2(0, -1);

    public static float gravitySpeed = 2;

    protected BoxCollider2D hitBox;
    protected ContactFilter2D SolidFilter;


    protected const float LEWAY = .05f;

    private void Awake()
    {
        SolidFilter.SetLayerMask(LayerMask.GetMask("Ground"));
    }

    protected virtual void Start()
    {
        velocity = gravity * gravitySpeed;

        hitBox = GetComponent<BoxCollider2D>();
    }

    protected virtual void FixedUpdate()
    {
        Collisions();
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

    private void Collisions()
    {
        RaycastHit2D[] checkForGround = new RaycastHit2D[5];
        int numHits;

        numHits = hitBox.Cast(velocity.normalized, SolidFilter, checkForGround, velocity.magnitude);

        for (int i = 0; i < numHits; i++)
        {
            ColliderDistance2D dist = hitBox.Distance(checkForGround[i].collider);

            if (!dist.isOverlapped)
            {
                velocity = new Vector2((velocity.x * dist.normal.y) * Mathf.Sign(velocity.y * -1),
                    (velocity.y * dist.normal.x) * Mathf.Sign(velocity.x * -1));

                velocity = new Vector2(velocity.x + (dist.distance - LEWAY) * (dist.normal.x * -1), velocity.y + (dist.distance - LEWAY) * (dist.normal.y * -1));
            }
            else
            {
                velocity = new Vector2(dist.normal.x * (dist.distance - LEWAY), dist.normal.y * (dist.distance - LEWAY));
            }
        }
    }
}
