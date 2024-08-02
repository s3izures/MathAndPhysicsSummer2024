using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollider : CustomCollider
{
    [SerializeField] private Transform tf;
    [SerializeField] private float offset;
    [SerializeField] private bool isDynamic;
    private float radius; //In order to get radius, divide diameter by 2
    private Vector2 center;

    private void Start()
    {
        center = tf.position;
        radius = (tf.localScale.x / 2 + tf.localScale.y / 2) / 2 + offset;
        UpdateCollider();
    }
    private void Update()
    {
        //In case it moves
        if (isDynamic)
        {
            center = tf.position;
            radius = (tf.localScale.x / 2 + tf.localScale.y / 2) / 2 + offset;
        }
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
        ColliderManager.Instance.AddCollider(this);
    }

    public float GetRadius()
    {
        return radius;
    }
    public Vector2 GetCenter()
    {
        return center;
    }
}
