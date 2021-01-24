    class InventoryItem
    {
        public string CategoryName { get; set; }
        public string FoodName { get; set; }
        public double Cost { get; set; }
        public double Quantity { get; set; }
        public override string ToString()
        {
            return $"{CategoryName} ({FoodName}) - Price: ${Cost:0.00}, Qty: {Quantity}";
        }
    }
