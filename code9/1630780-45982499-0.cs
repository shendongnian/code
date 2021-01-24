    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class CC : MonoBehaviour
    {
        private Vector3 moveDirection = Vector3.zero;
        private Animator _anim;
        private void Start()
        {
             _anim = GetComponent<Animator>();   
        }
        void Update()
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
    
            transform.Rotate(0, x, 0);
    
            if (Input.GetKey("w"))
            {
                _anim.Play("Walk");
                var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
                transform.Translate(0, 0, z); // Only move when "w" is pressed.
            }
            else
            {
                _anim.Play("Grounded");
            }
        }
    }
