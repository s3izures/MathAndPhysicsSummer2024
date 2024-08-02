using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class CollisionManager : MonoBehaviour
{
    public static CollisionManager cInstance;
    public List<CustomCollider> colliders = new List<CustomCollider>();

    void Start()
    {
        if (cInstance != null && cInstance != this)
        {
            Destroy(this);
        }
        else if (cInstance == null && cInstance != this)
        {
            cInstance = this;
        }
    }

    private void Update()
    {
        /* BROKEN, DELETES THE WRONG THING */
        if (colliders.Count > 1)
        {
            for (int i = 0; i < colliders.Count - 1; i++)
            {
                //Check between pickup and player
                if (colliders[i].GetTag() == CustomCollider.ColliderTag.Pickup && colliders[i + 1].GetTag() == CustomCollider.ColliderTag.Player)
                {
                    if (CheckCollisionCircles((CircleCollider)colliders[i], (CircleCollider)colliders[i + 1]))
                    {
                        //Add bit TBA

                        //Delete object
                        colliders.Remove(colliders[i]);
                        Destroy(colliders[i].gameObject);
                    }
                }
                else if (colliders[i + 1].GetTag() == CustomCollider.ColliderTag.Pickup && colliders[i].GetTag() == CustomCollider.ColliderTag.Player)
                {
                    if (CheckCollisionCircles((CircleCollider)colliders[i], (CircleCollider)colliders[i + 1]))
                    {
                        //Add bit TBA

                        //Delete object
                        colliders.Remove(colliders[i + 1]);
                        Destroy(colliders[i + 1].gameObject);
                    }
                }
            }
        }
    }

    public void AddCollision(CustomCollider collider)
    {
        colliders.Add(collider);
        Debug.Log(colliders[0]);
    }
    public void UpdateCollision(CustomCollider collider, int index)
    {
        colliders.RemoveAt(index);
        colliders.Insert(index, collider);
    }

    public bool CheckCollisionCircles(CircleCollider collider1, CircleCollider collider2)
    {
        bool collision = false;

        //Get distance between centers
        Vector2 distanceCenter = new Vector2 
                                (collider2.transform.position.x - collider1.transform.position.x,
                                 collider2.transform.position.y - collider1.transform.position.y);

        float distanceSquared = MathF.Pow((distanceCenter.x), 2) + MathF.Pow((distanceCenter.y), 2);
        float radiusSumSquared = MathF.Pow(collider1.GetRadius() + collider2.GetRadius(), 2);

        collision = (distanceSquared <= radiusSumSquared);

        return collision;
    }
}
