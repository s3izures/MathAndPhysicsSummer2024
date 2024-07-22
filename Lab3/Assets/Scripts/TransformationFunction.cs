using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class TransformationFunction : MonoBehaviour
{
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private Vector3 scaling;

    struct Matrix4
    {
        private float _11, _12, _13, _14,
                      _21, _22, _23, _24,
                      _31, _32, _33, _34,
                      _41, _42, _43, _44;

        public Matrix4( float m_11, float m_12, float m_13, float m_14,
                        float m_21, float m_22, float m_23, float m_24,
                        float m_31, float m_32, float m_33, float m_34,
                        float m_41, float m_42, float m_43, float m_44 )
        {
            _11 = m_11;
            _12 = m_12;
            _13 = m_13;
            _14 = m_14;

            _21 = m_21;
            _22 = m_22;
            _23 = m_23;
            _24 = m_24;

            _31 = m_31;
            _32 = m_32;
            _33 = m_33;
            _34 = m_34;

            _41 = m_41;
            _42 = m_42;
            _43 = m_43;
            _44 = m_44;
        }

        static Matrix4 Identity()
        {
            return new Matrix4( 1.0f, 0.0f, 0.0f, 0.0f,
                                0.0f, 1.0f, 0.0f, 0.0f,
                                0.0f, 0.0f, 1.0f, 0.0f,
                                0.0f, 0.0f, 0.0f, 1.0f );
        }

        static Matrix4 Translation(float x, float y, float z)
        {
            return new Matrix4( 1.0f, 0.0f, 0.0f, x   ,
                                0.0f, 1.0f, 0.0f, y   ,
                                0.0f, 0.0f, 1.0f, z   ,
                                0.0f, 0.0f, 0.0f, 1.0f);
        }

        static Matrix4 RotationX(float rad)
        {
            float s = Mathf.Sin(rad);
            float c = Mathf.Cos(rad);

            return new Matrix4( 1.0f, 0.0f, 0.0f, 0.0f,
                                0.0f, c   , s   , 0.0f,
                                0.0f, -s  , c   , 0.0f,
                                0.0f, 0.0f, 0.0f, 1.0f);
        }
        static Matrix4 RotationY(float rad)
        {
            float s = Mathf.Sin(rad);
            float c = Mathf.Cos(rad);

            return new Matrix4( c   , 0.0f, -s  , 0.0f,
                                0.0f, 1.0f, 0.0f, 0.0f,
                                s   , 0.0f, c   , 0.0f,
                                0.0f, 0.0f, 0.0f, 1.0f );
        }
        static Matrix4 RotationZ(float rad)
        {
            float s = Mathf.Sin(rad);
            float c = Mathf.Cos(rad);

            return new Matrix4( c   , s   , 0.0f, 0.0f,
                                -s  , c   , 0.0f, 0.0f,
                                0.0f, 0.0f, 1.0f, 0.0f,
                                0.0f, 0.0f, 0.0f, 1.0f);
        }

        static Matrix4 Scaling(float x, float y, float z)
        {
            return new Matrix4( x   , 0.0f, 0.0f, 0.0f,
                                0.0f, y   , 0.0f, 0.0f,
                                0.0f, 0.0f, z   , 0.0f,
                                0.0f, 0.0f, 0.0f, 1.0f);
        }
    };

    void Update()
    {
        
    }

    private void Translate()
    {
        
    }
    private void Rotation()
    {

    }
    private void Scaling()
    {

    }
}
