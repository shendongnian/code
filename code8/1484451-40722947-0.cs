    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    
    
    public class ChangeText : MonoBehaviour
    {
        private void Awake()
        {
            GameObject devButton = GameObject.Find("devButton");
            Text text = devButton.GetComponentInChildren<Text>();
            text.text = "Test";
        }
    }
