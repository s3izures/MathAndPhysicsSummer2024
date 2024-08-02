using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [Description("For more challenging gameplay, turn this on:")]
    [SerializeField] private Rigidbody2D rb;

    private MatrixHelper.Matrix4 transformation = new MatrixHelper.Matrix4().Identity();

    private void Start()
    {

    }

    void Update()
    {
        MatrixHelper.Matrix4 trans = new MatrixHelper.Matrix4().Translation2D(speed * Input.GetAxisRaw("Horizontal"),
                                                    speed * Input.GetAxisRaw("Vertical"));

        if (GameManager.Instance.GetCarMode()) //For more challenging gameplay + not the most proper use of translation
        {
            rb.AddForce(new Vector2 (trans.GetTranslation().x, trans.GetTranslation().y));
        }
        else //Moving circle by using matrix
        {
            transform.position = new Vector3(transform.position.x + trans.GetTranslation().x * Time.deltaTime,
                                             transform.position.y + trans.GetTranslation().y * Time.deltaTime,
                                             transform.position.z + trans.GetTranslation().z * Time.deltaTime);
        }
    }
}
