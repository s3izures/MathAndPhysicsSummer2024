using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomCollider : MonoBehaviour
{
    abstract public void DrawShape();
    abstract public void UpdateCollider();
}
