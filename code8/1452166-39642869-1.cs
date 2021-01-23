    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    
    public class Buttontextchange : MonoBehaviour {
        public Button BuyButton;
        public Text BuyText;
    
        void Start () {
             BuyButton.onClick.AddListener(clicked);
        }
    
        public void clicked()
        {
            Debug.Log("Button Buy Clicked!");
            BuyText.text = "i am a button!";
        }
    
    }
