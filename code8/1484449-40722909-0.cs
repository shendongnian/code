    using UnityEngine;
    using UnityEditor;
    using System.Collections;
    using UnityEngine.UI;
    
    
    [InitializeOnLoad]
    public class main : MonoBehaviour {
    
    
        static main()
        {
    
        }
    
        // Use this for initialization
        void Start () { 
            Debug.Log("Up and running");
            GameObject devButton = GameObject.Find("devButton");
            Text text = devButton.GetComponentInChildren<Text>();
            text.text = "Test";
        }
    
        // Update is called once per frame
        void Update () {
    
        }
    }
