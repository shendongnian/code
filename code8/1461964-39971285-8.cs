    class PriceLevels
    {
        public int[] priceLevels { get; private set; }
        private readonly int[] defaultPriceLevels = { 2, 3, 3, 4, 5, 6 };
        public PriceLevels(params int[] newPriceLevels)
        {
            priceLevels = newPriceLevels ?? defaultPriceLevels;
        }
    }
