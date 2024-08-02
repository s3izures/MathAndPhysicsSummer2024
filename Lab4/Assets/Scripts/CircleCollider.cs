using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollider : CustomCollider
{
    [SerializeField] private Transform tf;
    [SerializeField] private float radius;
    [SerializeField] private ColliderTag colliderTag;
    private Vector2 center;
    private int index = -1;

    private void Update()
    {
        center = tf.position;
        UpdateCollider();
    }
    public override ColliderTag GetTag()
    {
        return colliderTag;
    }

    public override void DrawShape()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(center, radius);
    }
    public void OnDrawGizmosSelected()
    {
        DrawShape();
    }
    public override void UpdateCollider()
    {
        if (index < 0)
        {
            CollisionManager.cInstance.AddCollision(this);
            index = CollisionManager.cInstance.colliders.IndexOf(this);
        }
        else
        {
            CollisionManager.cInstance.UpdateCollision(this, index);
        }
    }

    public float GetRadius()
    {
        return radius;
    }
}
