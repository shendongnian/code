    using UnityEngine;
    using System.Collections;
    public class playerControl : MonoBehaviour {
        private Rigidbody rb;
        public float speed;
     
        void Start()    //first Frame
        {
            rb = GetComponent<Rigidbody>();
        }
        void FixedUpdate()
        {
            //physics calc of object
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveX, 0.0f, moveZ);
            rb.AddForce(movement * speed);
        }
