using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.Animations;

public class TransformationFunction : MonoBehaviour
{
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private Vector3 scaling;
    [Header("local or world")]
    [SerializeField] private string option; //Choose between parent, local, or world
    Matrix4 originalMatrix;
    Matrix4 transformMatrix;

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

        public Matrix4(Matrix4 mat)
        {
            _11 = mat._11;
            _12 = mat._12;
            _13 = mat._13;
            _14 = mat._14;

            _21 = mat._21;
            _22 = mat._22;
            _23 = mat._23;
            _24 = mat._24;

            _31 = mat._31;
            _32 = mat._32;
            _33 = mat._33;
            _34 = mat._34;

            _41 = mat._41;
            _42 = mat._42;
            _43 = mat._43;
            _44 = mat._44;
        }

        public static Matrix4 Identity()
        {
            return new Matrix4( 1.0f, 0.0f, 0.0f, 0.0f,
                                0.0f, 1.0f, 0.0f, 0.0f,
                                0.0f, 0.0f, 1.0f, 0.0f,
                                0.0f, 0.0f, 0.0f, 1.0f );
        }

        public static Matrix4 Translation(float x, float y, float z)
        {
            Matrix4 matrix = Identity();
            matrix._41 = x;
            matrix._42 = y;
            matrix._43 = z;
            return matrix;
        }

        public static Matrix4 RotationX(float rad)
        {
            float s = Mathf.Sin(rad);
            float c = Mathf.Cos(rad);

            Matrix4 matrix = Identity();
            matrix._22 = c;
            matrix._23 = -s;
            matrix._32 = s;
            matrix._33 = c;

            return matrix;
        }
        public static Matrix4 RotationY(float rad)
        {
            float s = Mathf.Sin(rad);
            float c = Mathf.Cos(rad);

            Matrix4 matrix = Identity();
            matrix._11 = c;
            matrix._13 = s;
            matrix._31 = -s;
            matrix._33 = c;

            return matrix;
        }
        public static Matrix4 RotationZ(float rad)
        {
            float s = Mathf.Sin(rad);
            float c = Mathf.Cos(rad);

            Matrix4 matrix = Identity();
            matrix._11 = c;
            matrix._12 = -s;
            matrix._21 = s;
            matrix._22 = c;

            return matrix;
        }

        public static Matrix4 Scaling(float x, float y, float z)
        {
            Matrix4 matrix = Identity();
            matrix._11 = x;
            matrix._22 = y;
            matrix._33 = z;

            return matrix;
        }

        public Matrix4 Multiply (Matrix4 rhs)
        {
            Matrix4 result;

            result._11 = (_11 * rhs._11) + (_12 * rhs._21) + (_13 * rhs._31) + (_14 * rhs._41);
            result._12 = (_11 * rhs._12) + (_12 * rhs._22) + (_13 * rhs._32) + (_14 * rhs._42);
            result._13 = (_11 * rhs._13) + (_12 * rhs._23) + (_13 * rhs._33) + (_14 * rhs._43);
            result._14 = (_11 * rhs._14) + (_12 * rhs._24) + (_13 * rhs._34) + (_14 * rhs._44);

            result._21 = (_21 * rhs._11) + (_22 * rhs._21) + (_23 * rhs._31) + (_24 * rhs._41);
            result._22 = (_21 * rhs._12) + (_22 * rhs._22) + (_23 * rhs._32) + (_24 * rhs._42);
            result._23 = (_21 * rhs._13) + (_22 * rhs._23) + (_23 * rhs._33) + (_24 * rhs._43);
            result._24 = (_21 * rhs._14) + (_22 * rhs._24) + (_23 * rhs._34) + (_24 * rhs._44);

            result._31 = (_31 * rhs._11) + (_32 * rhs._21) + (_33 * rhs._31) + (_34 * rhs._41);
            result._32 = (_31 * rhs._12) + (_32 * rhs._22) + (_33 * rhs._32) + (_34 * rhs._42);
            result._33 = (_31 * rhs._13) + (_32 * rhs._23) + (_33 * rhs._33) + (_34 * rhs._43);
            result._34 = (_31 * rhs._14) + (_32 * rhs._24) + (_33 * rhs._34) + (_34 * rhs._44);

            result._41 = (_41 * rhs._11) + (_42 * rhs._21) + (_43 * rhs._31) + (_44 * rhs._41);
            result._42 = (_41 * rhs._12) + (_42 * rhs._22) + (_43 * rhs._32) + (_44 * rhs._42);
            result._43 = (_41 * rhs._13) + (_42 * rhs._23) + (_43 * rhs._33) + (_44 * rhs._43);
            result._44 = (_41 * rhs._14) + (_42 * rhs._24) + (_43 * rhs._34) + (_44 * rhs._44);

            return result;
        }

        public Vector3 GetMagnitude()
        {
            return new Vector3( Mathf.Sqrt(Mathf.Pow(_11, 2) + Mathf.Pow(_21, 2) + Mathf.Pow(_31, 2)),
                                Mathf.Sqrt(Mathf.Pow(_12, 2) + Mathf.Pow(_22, 2) + Mathf.Pow(_32, 2)),
                                Mathf.Sqrt(Mathf.Pow(_13, 2) + Mathf.Pow(_23, 2) + Mathf.Pow(_33, 2)));
        }

        public Vector3 GetTranslation()
        {
            return new Vector3(_41, _42, _43); //Get x, y, z
        }

        public Quaternion GetRotation()
        {
            float w = Mathf.Sqrt(1.0f + _11 + _22 + _33) / 2.0f;
            float x = (_23 - _32) / (4.0f * w);
            float y = (_31 - 13) / (4.0f * w);
            float z = (_12 - 21) / (4.0f * w);
            return new Quaternion(x, y, z,w);
        }

        public Vector3 GetUpwards()
        {
            return new Vector3(_12, _22, _32);
        }
        public Vector3 GetForwards()
        {
            return new Vector3(_13, _23, _33);
        }

    };

    void Update()
    {
        transformMatrix = Matrix4.Identity();

        //Scale
        transformMatrix = Matrix4.Scaling(scaling.x, scaling.y, scaling.z).Multiply(transformMatrix);
        //Rotation
        transformMatrix = Matrix4.RotationX(rotation.x).Multiply(transformMatrix);
        transformMatrix = Matrix4.RotationY(rotation.y).Multiply(transformMatrix);
        transformMatrix = Matrix4.RotationZ(rotation.z).Multiply(transformMatrix);
        //Translation
        transformMatrix = Matrix4.Translation(position.x,position.y,position.z).Multiply(transformMatrix);

        if (option == "world")
        {
            transform.rotation = Quaternion.LookRotation(transformMatrix.GetForwards(), transformMatrix.GetUpwards());
            transform.position = transformMatrix.GetTranslation();
        }
        else
        {
            transform.localRotation = Quaternion.LookRotation(transformMatrix.GetForwards(), transformMatrix.GetUpwards());
            transform.localPosition = transformMatrix.GetTranslation();
        }
        transform.localScale = transformMatrix.GetMagnitude(); //I don't think I can set world scale
    }
}
