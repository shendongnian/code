    public class YourClass : MonoBehaviour 
    {
        private Text sellButtonText;
        
        private int _sellAmount;
        public int SellAmount
        {
          get
          {
            return _sellAmount;
          }
          set 
          {
            _sellAmount = value;
            _sellButtonText = "Sell " + _sellAmount;
          }
        }
        
        
        void Start() 
        {
          _sellButtonText = GameObject.Find("The Object with Sell button").GetComponent<Text>();
        }
    }
