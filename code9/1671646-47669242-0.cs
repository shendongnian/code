        using UnityEngine;
        using UnityEngine.UI;
        using System.Collections;
        
        public class ClickExample : MonoBehaviour
        {
            public Button yourButton;
            public bool yourbool;
        
            void Start()
            {
                Button btn = yourButton.GetComponent<Button>();
                btn.onClick.AddListener(TaskOnClick);
                yourbool = false ;
            }
        
            void TaskOnClick()
            {
                yourbool != yourbool; // it will be true when clicked and false when clicked again
               if(yourbool)
               {
                // playsound
               }
               else
               {
                //stop sound
               }
                Debug.Log("You have clicked the button!");
            }
        }
