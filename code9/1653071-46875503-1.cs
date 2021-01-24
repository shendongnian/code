    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class TalkMalon : MonoBehaviour
    {
        private int index = 0;
        private string currentMessage = "";
        private float displayTime = 3;
        private bool showMessage = false;
        private bool selectNextMessage = false;
    
        public string[] messages = {
            "Hello, my name is Heinrich.",
            "I have nothing more to say."
        };
    
        void Update()
        {
            if (showMessage) {
                displayTime -= Time.deltaTime;
                if (displayTime <= 0.0) {
                    showMessage = false;
                    displayTime = 3;
    
                    Debug.Log(messages.Length);
    
                    if (index != messages.Length - 1) {
                        index++;
                    }
                }
            }
        }
    
        void OnTriggerStay()
        {
            if (Input.GetKeyDown(KeyCode.E)) {
                showMessage = true;
            }
        }
    
        void OnGUI()
        {
            if (showMessage) {
                GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), messages[index]);
            }
        }
    }
