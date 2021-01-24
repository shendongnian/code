    using UnityEngine;
    
    class SlowDown : MonoBehaviour
    { 
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Object " +other.name+" entered "+ name);
            WayPoints.SetSpeed(WayPoints.moveSpeedSlowed);
        }
    
        private void OnTriggerExit(Collider other)
        {
            Debug.Log("Object " + other.name + " exited " + name);
            WayPoints.SetSpeed(WayPoints.moveSpeed);
        }
    }
