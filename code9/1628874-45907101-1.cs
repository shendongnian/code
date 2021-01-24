    using UnityEngine;
    using System.Collections;
    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax, zMin, zMax;
    }
    
    public class PlayerController : MonoBehaviour
    {
        //public variables you can modify from the inspector
        public float speed;
        public float tilt;
        public Boundary boundary;
    
        void FixedUpdate ()
        {
            //To read the inputs of the player. The Horizontal and Vertical axis
            //Are defined in the Editor, Settings Manager, Input Manager.
            //You can change that for your own inputs like:
            //Input.GetKeyDown(KeyCode.Enter) or key you want to use
            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");
    
            //Creates a VEctor3D with the inputs and applies the movement
            Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
            rigidbody.velocity = movement * speed;
    
            //This part keeps the spaceship inside the boundary you passed as parameter
            rigidbody.position = new Vector3 
            (
                Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
                0.0f, 
                Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
            );
    
            //This part is just to make the spaceship tilt to one side or 
            //another to make it more realistic
            rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
        }
    }
