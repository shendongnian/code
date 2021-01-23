    public class Buttontextchange : MonoBehaviour
    {
        public Button BuyButton;
        public Text BuyText;
        void Start()
        {
            BuyButton.onClick.AddListener(OnButtonClicked);
            if (BuyText == null)
                BuyText = BuyButton.GetComponentInChildren<Text>();
        }
        public void OnButtonClicked()
        {
            Debug.Log("Button Buy Clicked!");
            BuyText.text = "i am a button!";
        }
    }
