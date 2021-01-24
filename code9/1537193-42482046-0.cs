    using UnityEngine;
    
    public class WayPoints : MonoBehaviour
    {
        //setters for setting everything in Unity editor
        public float moveSpeedSetter = 1f;
        public float moveSpeedSlowedSetter = 0.5f;
        public CharacterMotor motorSetter;
    
        //static objects changeable via any script
        public static float moveSpeed;
        public static float moveSpeedSlowed;
        public static CharacterMotor motor;
    
        public static void SetSpeed(float speed)
        {
            motor.movement.maxForwardSpeed = speed;
        }
    
        private void Start()
        {
            moveSpeed = moveSpeedSetter;
            moveSpeedSlowed = moveSpeedSlowedSetter;
            motor = motorSetter;
            motor.movement.maxForwardSpeed = moveSpeed;
        }
    }
