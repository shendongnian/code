    using UnityEngine;
    using UnityStandardAssets.Characters.FirstPerson;
    
    class SlowDown : MonoBehaviour
    { 
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Object " +other.name+" entered "+ name);
            WayPoints.SetSpeed(WayPoints.moveSpeedSlowedWalk, WayPoints.moveSpeedSlowedRun);
        }
    
        private void OnTriggerExit(Collider other)
        {
            Debug.Log("Object " + other.name + " exited " + name);
            WayPoints.SetSpeed(WayPoints.moveSpeedWalk, WayPoints.moveSpeedRun);
        }
    }
