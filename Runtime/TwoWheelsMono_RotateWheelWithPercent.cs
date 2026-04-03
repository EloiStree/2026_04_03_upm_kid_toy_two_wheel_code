using UnityEngine;

namespace Eloi.TwoWheelsCar
{
    public class TwoWheelsMono_RotateWheelWithPercent : MonoBehaviour
    {

        public Transform m_anchorReference;
        public Transform m_wheelToRotate;
        public float m_speedRotationPerSecond = 360;
        [Range(-1,1)]
        public float m_percentOfRotation = 0;

        public void SetPercentRotation(float percent) {
            m_percentOfRotation = percent;
        }
        public void SetAsRotatingForward(bool isRotating) {
            if (isRotating) 
                m_percentOfRotation = 1;
            else
                m_percentOfRotation = 0;
        }
        public void SetAsRotatingBackward(bool isRotating) {
            if (isRotating)
                m_percentOfRotation = -1;
            else
                m_percentOfRotation = 0;
        }
        public void SetAsNotRotating() {
            m_percentOfRotation = 0;
        }
        public void Update()
        {
            if (m_anchorReference == null || m_wheelToRotate == null)
                return;


            m_wheelToRotate.RotateAround(m_anchorReference.position, m_anchorReference.right, m_percentOfRotation * m_speedRotationPerSecond * Time.deltaTime);
        }



    }
}
