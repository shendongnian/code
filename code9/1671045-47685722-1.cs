    using UnityEngine;
    using System.Collections;
    public class Controller : MonoBehaviour
    {
        // ...
        Rigidbody2D rbody2D;
        void Start() {
            // ...
            rbody2D = GetComponent<Rigidbody2D>();
        }
        void FixedUpdate() {
            // One simple example of adding to the velocity.
            // Adds velocity in the x-axis such that the new x velocity
            //   is about equal to topSpeed in the direction we are trying to move.
            // Note that "Vector2.right * deltaVelX" = "new Vector2(deltaVelX, 0)".
            float move = Input.GetAxis("Horizontal");
            float deltaVelX = (move * topSpeed) - rbody2D.velocity.x;
            rbody2D.velocity += Vector2.right * deltaVelX;
        }
    }
