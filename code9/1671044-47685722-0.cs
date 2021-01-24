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
            rbody2D.velocity += //...
        }
    }
