    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class TalkMalon : MonoBehaviour
    {
        private string currentMessage = "";
        private float displayTime = 3;
        private bool showMessage = false;
        private bool selectNextMessage = false;
    
        public string[] messages = {
            "Hello, my name is Heinrich.",
            "I have nothing more to say."
        };
    
        public bool[] messageStatus = {
            false,
            false
        };
    
        void Start()
        {
            currentMessage = selectMessage(messages, messageStatus);
        }
    
        void Update()
        {
            if (showMessage) {
                displayTime -= Time.deltaTime;
                if (displayTime <= 0.0) {
                    showMessage = false;
                    displayTime = 3;
                    currentMessage = selectMessage(messages, messageStatus);
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
                GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), currentMessage);
            }
        }
    
        string selectMessage(string[] messages, bool[] status)
        {
    
            for (int i = 0; i <= status.Length-1; i++) {
                
                if (status[i] == false) {
                    status[i] = true;
                    Debug.Log(i);
                    Debug.Log(messages[i]);
    
                    return messages[i];
                }
            }
    
            return "Are you okay?";
        }
    }
