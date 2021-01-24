    using UnityEngine;
    using System.Collections;
    public class CameraMover : MonoBehaviour
    {
        public float speedH = 2.0f;
        public float speedV = 2.0f;
        private float yaw = 0.0f;
        private float pitch = 0.0f;
        public Transform playerTransform;
        public Transform mainCameraTransform = null;
        private Vector3 cameraOffset = Vector3.zero;
        public float turnSpeed = 3;
        // Create a camera parent object
        GameObject cameraParent;
        void Start()
        {
            cameraParent = new GameObject();
            mainCameraTransform = Camera.main.transform;
            //Get camera-player Transform Offset that will be used to move the camera 
            cameraOffset = mainCameraTransform.position - playerTransform.position;
            // Position the camera parent to the player and add the camera as a child
            cameraParent.transform.position = playerTransform.position;
            mainCameraTransform.parent = cameraParent.transform;
        }
        void LateUpdate()
        {
            //Move the camera to the position of the playerTransform with the offset that was saved in the begining
            //mainCameraTransform.position = playerTransform.position + cameraOffset;
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");
            // Rotate the camera parent instead of the camera
            cameraParent.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
