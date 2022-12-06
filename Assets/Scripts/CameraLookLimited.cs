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

        /// 限制相机左右视角的角度

        ///

        /// 角度

        private void LimitAngle(float angle)

        {

            vect = this.transform.eulerAngles;

            //当前相机x轴旋转的角度(0~360)

            xcream = IsPosNum(vect.x);

            if (xcream > angle)

                this.transform.rotation = Quaternion.Euler(angle, vect.y, 0);

            else if (xcream < -angle)

                this.transform.rotation = Quaternion.Euler(-angle, vect.y, 0);

        }

        ///

        /// 限制相机上下视角的角度

        ///

        ///

        private void LimitAngleUandD(float angle)

        {

            vect = this.transform.eulerAngles;

            //当前相机y轴旋转的角度(0~360)

            ycream = IsPosNum(vect.y);

            if (ycream > angle)

                this.transform.rotation = Quaternion.Euler(vect.x, angle, 0);

            else if (ycream < -angle)

                this.transform.rotation = Quaternion.Euler(vect.x, -angle, 0);

        }

        ///

        /// 将角度转换为-180~180的角度

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
