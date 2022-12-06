using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookLimited : MonoBehaviour
{
   

        public int speed = 5;

        private Vector3 vect;

        private float xcream;

        private float ycream;

        public void Update()

        {

            CreamView();

        }

        private void CreamView()

        {

            float x = Input.GetAxis("Mouse X");

            float y = Input.GetAxis("Mouse Y");

            if (x != 0 || y != 0)

            {

                LimitAngle(60);

                LimitAngleUandD(60);

                this.transform.Rotate(-y * speed, 0, 0);

                this.transform.Rotate(0, x * speed, 0, Space.World);

            }

        }

        ///

        /// ������������ӽǵĽǶ�

        ///

        /// �Ƕ�

        private void LimitAngle(float angle)

        {

            vect = this.transform.eulerAngles;

            //��ǰ���x����ת�ĽǶ�(0~360)

            xcream = IsPosNum(vect.x);

            if (xcream > angle)

                this.transform.rotation = Quaternion.Euler(angle, vect.y, 0);

            else if (xcream < -angle)

                this.transform.rotation = Quaternion.Euler(-angle, vect.y, 0);

        }

        ///

        /// ������������ӽǵĽǶ�

        ///

        ///

        private void LimitAngleUandD(float angle)

        {

            vect = this.transform.eulerAngles;

            //��ǰ���y����ת�ĽǶ�(0~360)

            ycream = IsPosNum(vect.y);

            if (ycream > angle)

                this.transform.rotation = Quaternion.Euler(vect.x, angle, 0);

            else if (ycream < -angle)

                this.transform.rotation = Quaternion.Euler(vect.x, -angle, 0);

        }

        ///

        /// ���Ƕ�ת��Ϊ-180~180�ĽǶ�

        ///

        ///

        ///

        private float IsPosNum(float x)

        {

            x -= 180;

            if (x < 0)

                return x + 180;

            else return x - 180;

        }

    

}
