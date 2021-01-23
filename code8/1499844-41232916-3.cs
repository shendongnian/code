    abstract class Item
    {
        private string _productName; 
        private Button _buyButton = null;
        public Item(string productName)
        {
            _productName = productName;
        }
        public Button BuyButton
        {
            get
            {
                if (_buyButton == null) CreateBuyButton(_productName); //Lazy initialization
                return _buyButton;
            }
        }
        public abstract void CreateBuyButton(string caption);
    }
