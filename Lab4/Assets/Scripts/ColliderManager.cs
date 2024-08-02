using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    /// <summary>
    /// Collider Manager will handle all things related to the interaction of colliders with each other.  In short, collisions.
    /// </summary>

    public static ColliderManager Instance;
    private int playerCollider = -1;
    [SerializeField] private List<CustomCollider> colliders;

    void Awake()
    {
        if (Instance == null && Instance != this)
        {
            colliders.Clear();
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        foreach(var collider in colliders)
        {
            Debug.Log(collider);
        }
    }
    void Update()
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            //Keep updating player collider in case List changes
            if (colliders[i].gameObject.CompareTag("Player"))
            {
                playerCollider = i;
            }
            //Check collisions if player exists
            else if (i != playerCollider && playerCollider > -1 && colliders[i].enabled)
            {
                if (colliders[i].gameObject.CompareTag("Pickup"))
                {
                    if (CheckCollisionCircles((CircleCollider)colliders[playerCollider], (CircleCollider)colliders[i]))
                    {
                        GameManager.Instance.ModifyPickupAmount(colliders[i].gameObject.GetComponent<Attributes>());
                        DisableCollider(colliders[i]);
                    }
                }
                else if (colliders[i].gameObject.CompareTag("Wall"))
                {
                    if (CheckCollisionCircleRect((CircleCollider)colliders[playerCollider], (RectangleCollider)colliders[i])) //Not working yet
                    {
                        Debug.Log("ur kissing a wall: " + colliders[i]);
                    }
                }
            }
        }
    }
    public int AddCollider(CustomCollider other)
    {
        colliders.Insert(colliders.Count, other);
        Debug.Log(other);
        return colliders.Count - 1;
    }
    public void DisableCollider(CustomCollider collider)
    {
        collider.gameObject.SetActive(false);
        collider.enabled = false;
    }



    //==========================================================================================
    //Collision Checks
    //==========================================================================================

    public bool CheckCollisionCircles(CircleCollider collider1, CircleCollider collider2)
    {
        bool collision = false;

        //Get distance between centers
        Vector2 distanceCenter = new Vector2 (collider2.GetCenter().x - collider1.GetCenter().x,
                                              collider2.GetCenter().y - collider1.GetCenter().y);

        float distanceSquared = MathF.Pow((distanceCenter.x), 2) + MathF.Pow((distanceCenter.y), 2);
        float radiusSumSquared = MathF.Pow(collider1.GetRadius() + collider2.GetRadius(), 2);

        collision = (distanceSquared <= radiusSumSquared);

        return collision;
    }
    public bool CheckCollisionCircleRect(CircleCollider collider1, RectangleCollider collider2) //Not working yet
    {
        bool collision = false;

        Vector2 centerDifference = new Vector2 (MathF.Abs(collider1.GetCenter().x - collider2.GetCenter().x),
                                                MathF.Abs(collider1.GetCenter().y - collider2.GetCenter().y));

        if (centerDifference.x > collider2.GetSize().x/2.0f + collider1.GetRadius() || centerDifference.y > collider2.GetSize().y / 2.0f + collider1.GetRadius())
        {
            collision = false;
        }
        else if (centerDifference.x <= collider2.GetSize().x / 2.0f + collider1.GetRadius() || centerDifference.y <= collider2.GetSize().y / 2.0f + collider1.GetRadius())
        {
            collision = true;
        }
        else
        {

            float cornerDistanceSq = Mathf.Pow(centerDifference.x - collider2.GetSize().x / 2.0f, 2) + Mathf.Pow(centerDifference.y - collider2.GetSize().y / 2.0f, 2);
            collision = (cornerDistanceSq <= MathF.Pow(collider1.GetRadius(), 2));
        }

        return collision;
    }
}
