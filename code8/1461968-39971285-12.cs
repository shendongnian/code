    class PriceLevels
    {
        public int[] priceLevels { get; set; }
        private readonly int[] defaultPriceLevels = { 2, 3, 3, 4, 5, 6 };
    
        public PriceLevels()
        {
            priceLevels = defaultPriceLevels;
        }
    
        public PriceLevels(int[] newPriceLevels)
        {
           priceLevels = newPriceLevels;
        }
    }
