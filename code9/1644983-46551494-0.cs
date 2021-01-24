    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    [ExecuteInEditMode]
    public class CanvasPositioner : MonoBehaviour {
        public Camera cam;
        public Canvas[] canvases;
        public float distance = 15;
    
        private float xPos;
        private float yPos;
        private float zPos;
        private float angle;
        
    	void PositionCanvases(){
            for(int i = 0; i < canvases.Length; i++){
                angle = canvases[i].transform.eulerAngles.y;
                xPos = cam.transform.position.x + distance * Mathf.Sin(Mathf.Deg2Rad* angle);
                yPos = cam.transform.position.y;
                zPos = cam.transform.position.z + distance * Mathf.Cos(Mathf.Deg2Rad * angle);
                canvases[i].transform.position = new Vector3(xPos,yPos,zPos);
            }
        }
    	void LateUpdate () {
            PositionCanvases();
        }
    }
