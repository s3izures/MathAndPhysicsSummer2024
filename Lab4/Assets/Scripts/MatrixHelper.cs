using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixHelper : MonoBehaviour
{
    public struct Matrix4
    {
        private float m_11, m_12, m_13, m_14,
                        m_21, m_22, m_23, m_24,
                        m_31, m_32, m_33, m_34,
                        m_41, m_42, m_43, m_44;

        public Matrix4(float _11, float _12, float _13, float _14,
                        float _21, float _22, float _23, float _24,
                        float _31, float _32, float _33, float _34,
                        float _41, float _42, float _43, float _44)
        {
            m_11 = _11; m_12 = _12; m_13 = _13; m_14 = _14;
            m_21 = _21; m_22 = _22; m_23 = _23; m_24 = _24;
            m_31 = _31; m_32 = _32; m_33 = _33; m_34 = _34;
            m_41 = _41; m_42 = _42; m_43 = _43; m_44 = _44;
        }
        public Matrix4 Identity()
        {
            return new Matrix4(1, 0, 0, 0,
                                0, 1, 0, 0,
                                0, 0, 1, 0,
                                0, 0, 0, 1);
        }

        private void Dot(Matrix4 mat)
        {
            //ROW 1
            float r1_1 = (m_11 * mat.m_11) + (m_12 * mat.m_21) + (m_13 * mat.m_31);
            float r1_2 = (m_11 * mat.m_12) + (m_12 * mat.m_22) + (m_13 * mat.m_32);
            float r1_3 = (m_11 * mat.m_13) + (m_12 * mat.m_23) + (m_13 * mat.m_33);
            float r1_4 = (m_11 * mat.m_14) + (m_12 * mat.m_24) + (m_13 * mat.m_34);

            //ROW 2
            float r2_1 = (m_21 * mat.m_11) + (m_22 * mat.m_21) + (m_23 * mat.m_31);
            float r2_2 = (m_21 * mat.m_12) + (m_22 * mat.m_22) + (m_23 * mat.m_32);
            float r2_3 = (m_21 * mat.m_13) + (m_22 * mat.m_23) + (m_23 * mat.m_33);
            float r2_4 = (m_21 * mat.m_14) + (m_22 * mat.m_24) + (m_23 * mat.m_34);

            //ROW 3
            float r3_1 = (m_31 * mat.m_11) + (m_32 * mat.m_21) + (m_33 * mat.m_31);
            float r3_2 = (m_31 * mat.m_12) + (m_32 * mat.m_22) + (m_33 * mat.m_32);
            float r3_3 = (m_31 * mat.m_13) + (m_32 * mat.m_23) + (m_33 * mat.m_33);
            float r3_4 = (m_31 * mat.m_14) + (m_32 * mat.m_24) + (m_33 * mat.m_34);

            //ROW 4
            float r4_1 = (m_41 * mat.m_11) + (m_42 * mat.m_21) + (m_43 * mat.m_31);
            float r4_2 = (m_41 * mat.m_12) + (m_42 * mat.m_22) + (m_43 * mat.m_32);
            float r4_3 = (m_41 * mat.m_13) + (m_42 * mat.m_23) + (m_43 * mat.m_33);
            float r4_4 = (m_41 * mat.m_14) + (m_42 * mat.m_24) + (m_43 * mat.m_34);

            m_11 = r1_1; m_12 = r1_2; m_13 = r1_3; m_14 = r1_4;
            m_21 = r2_1; m_22 = r2_2; m_23 = r2_3; m_24 = r2_4;
            m_31 = r3_1; m_32 = r3_2; m_33 = r3_3; m_34 = r3_4;
            m_41 = r4_1; m_42 = r4_2; m_43 = r4_3; m_44 = r4_4;
        }
        public Matrix4 Translation2D(float x, float y)
        {
            Matrix4 trans = Identity();
            trans.m_14 = x;
            trans.m_24 = y;
            trans.m_34 = 0; //z value

            return trans;
        }
        public Vector3 GetTranslation()
        {
            return new Vector3(m_14, m_24, m_34);
        }

        //ADD ROTATION
    }
}
