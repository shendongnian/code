    using System;
    using UnityEngine;
    
    /// <summary>
    /// The MainCameraEllipticalMWE class provides motion of the camera in an ellipse (or a circle)
    /// given sizeX and sizeZ where one is the major axis and the other the minor axis.  Which is
    /// which isn't important, and they can be equal (x == z) if the camera is to track in a circle.
    ///
    /// The size values assume a 2D surface where x=0, z=0 is at the bottom left and built in both x+
    /// and z+ directions.
    /// </summary>
    public class MainCameraEllipticalMWE : MonoBehaviour
    {
        // sizeX and sizeZ are provided here to provide a reference point. In use, my version
        // of this script omits these values and gets values from a manager object fed into
        // the FixCamera() method where xAmplitude and zAmplitude are set.
        int sizeX = 12;
        int sizeZ = 3;
        Vector3 center;
        float height;
        float fudgeFactor = 1.0f;
    
        float phase = 0f;
        float xAmplitude = 0f;
        float zAmplitude = 0f;
        float x;
        float z;
    
        void Awake()
        {
            this.FixCamera(sizeX, sizeZ);
        }
    
        /// <summary>
        /// On Update(), if the appropriate key is pressed, rotate the camera around the center
        /// of the area defined. The camera will tilt as appropriate to maintain the same center
        /// point of view.  The greater the difference between the major and minor axes, the
        /// greater the difference of speed as the camera traverses the outsides of the major axis.
        /// </summary>
        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                // Move left
                phase -= 0.01f;
                x = xAmplitude * Mathf.Cos(phase);
                z = zAmplitude * Mathf.Sin(phase);
                transform.localPosition = new Vector3(x, height, z) + center;
                this.GetComponent<Camera>().transform.LookAt(center);
            }
    
            else if (Input.GetKey(KeyCode.F))
            {
                // Move right
                phase += 0.01f;
                x = xAmplitude * Mathf.Cos(phase);
                z = zAmplitude * Mathf.Sin(phase);
                transform.localPosition = new Vector3(x, height, z) + center;
                this.GetComponent<Camera>().transform.LookAt(center);
            }
        }
    
        /// <summary>
        /// FixCamera() provides the initial camera position, sets the camera height, and
        /// resolves the center position based on the horizontal and vertical sizes of
        /// the screen area.
        /// </summary>
        /// <param name="horizontalSize"></param>
        /// <param name="verticalSize"></param>
        public void FixCamera(int horizontalSize, int verticalSize)
        {
            xAmplitude = horizontalSize;
            zAmplitude = verticalSize;
            height = Math.Max(horizontalSize, verticalSize) + fudgeFactor;
            center = new Vector3((float)horizontalSize / 2, 0, (float)verticalSize / 2);
    
            float x = xAmplitude * Mathf.Cos(phase);
            float z = zAmplitude * Mathf.Sin(phase);
            transform.localPosition = new Vector3(x, height, z) + center;
            this.GetComponent<Camera>().transform.LookAt(center);
        }
    }
