      using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        
        public class CameraFollowPlayer : MonoBehaviour
        {
        
            public GameObject target;
        	public GameObject cameraRig;
            public float rotateSpeedX = 9.0f;
        	public float rotateSpeedY = 5f;
        
        	float cameraAngle;
        	float startCameraAngle;
        
            Vector3 offset;
        	Vector3 currentOffset;
        
        	bool isCameraMoving;
        
        
            void Start()
            {
        		offset = transform.position - target.transform.position;
        
        		cameraAngle = transform.localEulerAngles.z;
        		startCameraAngle = cameraAngle;
        		currentOffset = offset;
        
            }
        
        	void Update()
        	{
        
        		transform.position = target.transform.position + currentOffset; // Folgt dem Spieler
        
        		float hor = Input.GetAxisRaw("RightJoystickX") * rotateSpeedX; // Input rechter Joystick    GetAxis wenn Bewegung ausschwingen soll
        		float ver = Input.GetAxisRaw("RightJoystickY") * rotateSpeedY; // GetAxis wenn Bewegung ausschwingen soll
        
        
        		if (!Mathf.Approximately (hor, 0)) {
        			transform.RotateAround (target.transform.position, Vector3.up, hor);
        			currentOffset = transform.position - target.transform.position;
        
        		}
        
        
                if (ver != 0) {
        
        			//cameraAngle += 110f * Time.deltaTime;
                    if (ver > 0)
                    {
        
                        cameraAngle += 110f * Time.deltaTime;
                        if (cameraAngle >= 420f)
                        {
                            cameraAngle = 420f;
                        }
        
                    }
                    if (ver < 0)
                    {
        
                        cameraAngle -= 110f * Time.deltaTime;
        
                        if (cameraAngle <= 290f)
                        {
                            cameraAngle = 290f;
                        }
                    }
                    
        
                    transform.RotateAround (target.transform.position, Vector3.up, hor);
        			currentOffset = transform.position - target.transform.position;
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, cameraAngle);
        
                }
        
                else
                {
                    cameraAngle = Mathf.Lerp(startCameraAngle, cameraAngle, 1f - 0.9f * Time.deltaTime);
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, cameraAngle);
        
                }
