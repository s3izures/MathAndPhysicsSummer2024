using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomCollider : MonoBehaviour
{
    public enum ColliderTag
    {
        Player,
        Pickup,
        Wall,
        Gate
    }
    abstract public ColliderTag GetTag();
    abstract public void DrawShape();
    abstract public void UpdateCollider();
}
