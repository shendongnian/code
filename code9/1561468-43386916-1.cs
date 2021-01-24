    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class NewBehaviourScript : MonoBehaviour {
        public float speed = 6.0f;
        //public float j
        Transform groundCheck;  // For checking if grounded
        //private float overlapRadius = 0.2f;  // For checking if grounded
        public LayerMask whatisGround;  // A layer mask to distinguish what is considered as ground
        private bool grounded = false;  // True when Mario is touching ground
        private bool jump = false;      // Flag to check when player intends to jump
        public float jumpForce = 700f;  // How much force we will apply to our jump
        private bool doubleJump = false;  // This becomes true once we have double-jumped
        public int dJumpLimit = 5;  // A limit to prevent too many jumps happening
        void Start()
        {
            // Find the Transform called "groundcheck"
            groundCheck = transform.Find ("groundcheck"); 
            // Set the PlayerPrefs integer called "doublejumps" to the value of dJumpLimit
            PlayerPrefs.SetInt ("doublejumps", dJumpLimit);
        }
        void Update()
        { 
            // If Space is being pressed...
            if (Input.GetKey(KeyCode.Space)) 
            {
                jump = true;  // Set jump bool to true to indicate our intention to jump
            }
        //perhaps put A and D here?
        }
        void FixedUpdate()
        {
            //to check if Mario is on the ground - this is necessary so we can't jump forever
            //overlap collider replace Overlap Circle???
            //overlap point??
            //grounded = GetComponent<Rigidbody2D> ().OverlapCollision(groundCheck.position, overlapRadius, whatisGround);
            // If Mario is touching ground...
            if (grounded)
                doubleJump = false;  // Make sure that as we are grounded we are not allowed to "jump again"
            if (dJumpLimit < 1)
                doubleJump = true;
            // Set a new bool to true if grounded is true OR doubleJump is false
            bool canJump = (grounded || !doubleJump);
            // If the player pressed space AND we are allowed to jump...
            if (jump && canJump) {
                // Apply existing x velocity to the x direction 
                GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, 0);
                // Apply our jump force to the y direction 
                GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));
            // If doubleJump is false AND we are not grounded...
            if (!doubleJump && !grounded) {
                doubleJump = true;  // We have double jumped so set to true
                dJumpLimit--;  // Decrement one from dJumpLimit
            }
        }
            jump = false;  // Reset the jump bool to false
            //code that will work with the limits?
            //GetComponent<Rigidbody2D>().velocity = new Vector2(speed,GetComponent<Rigidbody2D>().velocity.y);
            //this will make it stack?
            //GetComponent<Rigidbody2D>().velocity = new Vector2(speed,GetComponent<Rigidbody2D>().velocity.x);
            //GetComponent<Rigidbody2D>().velocity = new Vector2(speed,GetComponent<Rigidbody2D>().velocity.y);
        }
    }
