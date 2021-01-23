    abstract class Item
    { 
        private Button _buyButton = null;
        public Item()
        {
            //Do nothing
        }
        public Button BuyButton
        {
            get
            {
                if (_buyButton == null) CreateButton(); //Lazy initialization
                return _buyButton;
            }
        }
    }
