    using UnityEngine;
    using System.Collections;
    
    public class Example : MonoBehaviour
    {
        public Transform Player;
    
        void Update()
        {
            //Rotating Around Circle(circular movement depend on mouse position)
            Vector3 targetScreenPos = Camera.main.WorldToScreenPoint(Player.position);
            targetScreenPos.z = 0;//filtering target axis
            Vector3 targetToMouseDir = Input.mousePosition - targetScreenPos;
    
            Vector3 targetToMe = transform.position - Player.position;
    
            targetToMe.z = 0;//filtering targetToMe axis
    
            Vector3 newTargetToMe = Vector3.RotateTowards(targetToMe, targetToMouseDir,  /* max radians to turn this frame */ 2, 0);
            
            transform.position = Player.position +  /*distance from target center to stay at*/newTargetToMe.normalized;
    
    
            //Look At Mouse position
            var objectPos = Camera.main.WorldToScreenPoint(transform.position);
            var dir = Input.mousePosition - objectPos;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
    
        }
    }
