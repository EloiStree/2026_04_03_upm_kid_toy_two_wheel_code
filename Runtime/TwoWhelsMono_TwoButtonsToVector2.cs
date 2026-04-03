using UnityEngine;
using UnityEngine.Events;


namespace Eloi.TwoWheelsCar {
    public class TwoWhelsMono_TwoButtonsToVector2 : MonoBehaviour { 
    
        public UnityEvent<Vector2> m_onJoystickUpdated;
        public UnityEvent<bool> m_onLeftValueUpdated;
        public UnityEvent<bool> m_onRightValueUpdated;

        public bool m_buttonLeft;
        public bool m_buttonRight;




        public void OnValidate()
        {
            //To test from the editor 
            // On validate means when the value changed in inpsector of unity.
            UpdateJoystick();

        }

        public void SetButtonLeft(bool stateIsPressed) {
            m_buttonLeft = stateIsPressed;
            UpdateJoystick();
        }
        public void SetButtonRight(bool stateIsPressed) {
            m_buttonRight = stateIsPressed;
            UpdateJoystick();
        }

        public void UpdateJoystick() {

            // if one is left rotate left
            // if one is right rotate right
            // if both are pressed, go forward
            // if none is pressed, stop

            Vector2 joystick = Vector2.zero;
            if (m_buttonLeft && m_buttonRight) {
                joystick.y =1;
                joystick.x = 0;
            }
            else if (m_buttonLeft) {
                joystick.y = 0;
                joystick.x = -1;
            }
            else if (m_buttonRight) {
                joystick.y = 0;
                joystick.x = 1;
            }
            else {
                joystick.y = 0;
                joystick.x = 0;
            }
            m_onLeftValueUpdated.Invoke(m_buttonLeft);
            m_onRightValueUpdated.Invoke(m_buttonRight);
            m_onJoystickUpdated.Invoke(joystick);
        }

    }

}