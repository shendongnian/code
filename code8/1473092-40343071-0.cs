    public class Product
    {
        public event FlowerEventHandler StockDecreased; 
        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                int newQuantity = value;
                if (newQuantity < _quantity)
                {
                   if (StockDecreased != null) StockDecreased();
                }
                _quantity = newQuantity;
            }
        }
        // Other stuff
    }
