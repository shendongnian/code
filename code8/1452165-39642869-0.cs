    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    
    public class Buttontextchange : MonoBehaviour {
        public Button BuyButton;
        public Text BuyText;
    
    
        // Use this for initialization
        void Start () {
             BuyButton.onClick.AddListener(clicked);
        }
    
        // Update is called once per frame
        void Update () {
    
        }
    
        public void clicked()
        {
            Debug.Log("Button Buy Clicked!");
            BuyText.text = "i am a button!";
        }
    
    }
