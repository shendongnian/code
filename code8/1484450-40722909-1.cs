    using UnityEngine;
    using UnityEditor;
    using System.Collections;
    using UnityEngine.UI;
    
    
    public class main : MonoBehaviour {
    
        void Awake () { 
            Debug.Log("Up and running");
            GameObject devButton = GameObject.Find("devButton");
            Text text = devButton.GetComponentInChildren<Text>();
            text.text = "Test";
        }
    }
