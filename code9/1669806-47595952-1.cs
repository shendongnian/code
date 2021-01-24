    public class ViewModelShoppingCartItem
    {
        // ...
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal LineSum => ProductPrice * Quantity;
    }
