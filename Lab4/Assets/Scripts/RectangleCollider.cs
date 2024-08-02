using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CustomCollider;

public class RectangleCollider : CustomCollider
{
    [SerializeField] private Transform tf;
    [SerializeField] private Vector2 offset;
    [SerializeField] private bool isDynamic;
    private Vector2 size;
    private Vector2 center;

    private void Start()
    {
        center = tf.position;
        size.x = tf.localScale.x + offset.x;
        size.y = tf.localScale.y + offset.y;
        UpdateCollider();
    }
    private void Update()
    {
        //In case it moves
        if (isDynamic)
        {
            center = tf.position;
            size = tf.localScale;
            size.x = tf.localScale.x + offset.x;
            size.y = tf.localScale.y + offset.y;
        }
    }

    public override void DrawShape()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(tf.position, new Vector3(size.x, size.y, 1));
    }
    public void OnDrawGizmosSelected()
    {
        DrawShape();
    }
    public override void UpdateCollider()
    {
        ColliderManager.Instance.AddCollider(this);
    }

    public Vector2 GetCenter()
    {
        return center;
    }
    public Vector2 GetSize()
    {
        return size;
    }
}
