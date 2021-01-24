    using UnityEngine;
    using UnityStandardAssets.Characters.FirstPerson;
    
    public class WayPoints : MonoBehaviour
    {
        //setters for setting everything in Unity editor
        public float moveSpeedRunSetter = 10f;
        public float moveSpeedSlowedRunSetter = 6f;
        public float moveSpeedWalkSetter = 5f;
        public float moveSpeedSlowedWalkSetter = 3f;
        public FirstPersonController motorSetter;
    
        //static objects changeable via any script
        public static float moveSpeedRun;
        public static float moveSpeedSlowedRun;
        public static float moveSpeedWalk;
        public static float moveSpeedSlowedWalk;
        public static FirstPersonController motor;
    
        public static void SetSpeed(float walk, float run)
        {
            motor.ChangeSpeed(walk, run);
        }
    
        private void Start()
        {
            moveSpeedWalk = moveSpeedWalkSetter;
            moveSpeedSlowedWalk = moveSpeedSlowedWalkSetter;
            moveSpeedRun = moveSpeedRunSetter;
            moveSpeedSlowedRun = moveSpeedSlowedRunSetter;
            motor = motorSetter;
            motor.ChangeSpeed(moveSpeedWalk, moveSpeedRun);
        }
    }
