using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


namespace Eloi.TwoWheelsCar {

    public class TwoWheelsCarMoveEasyMode : MonoBehaviour
    {

        public CharacterController m_characterToMove;


        [Header("Designer Setting")]
        public float m_rotationSpeedInDegreesPerSecond = 90f;
        public float m_backForwardInMeterPerSecond = 0.1f;
        public float m_fakeGravityInMeterPerSecond = 0.4f;

        [Header("User Input")]
        [Range(-1,1)]
        public float m_rotationLeftRightPercent = 0.1f;
        [Range(-1, 1)]
        public float m_moveBackForwardPercent = 0.1f;


        public void SetMoveWithPercent11(float moveBackForwardPercent11)
        {
            m_moveBackForwardPercent = moveBackForwardPercent11;
        }
        public void SetRotateWithPercent11(float rotateLeftRightPercent11)
        {
            m_rotationLeftRightPercent = rotateLeftRightPercent11;
        }

        public void SetMoveAndRotateWithVector2(Vector2 moveAndRotate)
        {
            m_moveBackForwardPercent = moveAndRotate.y;
            m_rotationLeftRightPercent = moveAndRotate.x;
        }


        public void SetAsMoveForward(bool isMovingForward) {

            if ( isMovingForward)
            {
                m_moveBackForwardPercent = 1f;
            }
            else
            {
                m_moveBackForwardPercent = 0f;

            }
        }
        public void SetAsMoveBackward(bool isMovingBackward)
        {
            if (isMovingBackward)
            {
                m_moveBackForwardPercent = -1f;
            }
            else
            {
                m_moveBackForwardPercent = 0f;
            }
        }
        public void SetAsRotatingLeft(bool isRotatingLeft)
        {
            if (isRotatingLeft)
            {
                m_rotationLeftRightPercent = -1f;
            }
            else
            {
                m_rotationLeftRightPercent = 0f;
            }
        }
        public void SetAsRotatingRight(bool isRotatingRight)
        {
            if (isRotatingRight)
            {
                m_rotationLeftRightPercent = 1f;
            }
            else
            {
                m_rotationLeftRightPercent = 0f;
            }
        }



        void Start()
        {
            Debug.Log("Hello World ;) O-O ");
        }

        // Update is called once per frame
        void Update()
        {
            float timeBetweenFrames = Time.deltaTime; // Around 0.05 seconds for 60 FPS
            float rotationPerFrame = m_rotationSpeedInDegreesPerSecond * timeBetweenFrames;
            float moveMeterPerFrame = m_backForwardInMeterPerSecond * timeBetweenFrames;
            float rotationWantedByUser = rotationPerFrame * m_rotationLeftRightPercent;
            float moveWantedByUser = moveMeterPerFrame * m_moveBackForwardPercent;

            //Lets rotate
            m_characterToMove.transform.Rotate(new Vector3(0, 1, 0), rotationWantedByUser, Space.Self);

            //Lets move
            Vector3 direction = m_characterToMove.transform.forward.normalized ;
            Vector3 toMoveDirection  = direction * moveWantedByUser;

            // Is it a local direction or a global direction? 
            m_characterToMove.Move(toMoveDirection);


            // Not a good idea to not check. But hey if it works.
            // We can do better more complexe code later in the development.
            Vector3 gravityDirection = Vector3.down * m_fakeGravityInMeterPerSecond * timeBetweenFrames;
            m_characterToMove.Move(gravityDirection);
        


        }
    }

}