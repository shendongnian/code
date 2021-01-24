    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class CharacterControls : MonoBehaviour {
    
        public float base_speed = 3.0f;
        public float max_speed = 6.0f;
        private float current_speed;
    
        // Use this for initialization
        void Start () {
            current_speed = base_speed;
            Cursor.lockState = CursorLockMode.Locked;
        }
    
        // Update is called once per frame
        void Update () {
    
            if (Input.GetKey(KeyCode.W) && current_speed < max_speed) {
                current_speed += 1 * Time.deltaTime;
            } else if (!Input.GetKey(KeyCode.W) && current_speed > base_speed) {
                current_speed -= 1 * Time.deltaTime;
            }
    
            float translation = Input.GetAxis("Vertical") * current_speed;
            float strafe = Input.GetAxis("Horizontal") * current_speed;
            translation *= Time.deltaTime;
            strafe *= Time.deltaTime;
    
            transform.Translate(strafe, 0, translation);
    
            if (Input.GetKeyDown("escape"))
                Cursor.lockState = CursorLockMode.None;
        }
    }
