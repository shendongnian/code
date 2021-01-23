    public class PriceCalculator
    {
        public double Price(WomensFashionItem item)
        {
            return item.Cost * 1.2;
        }
        public double Price(MensFashionItem item)
        {
            return item.Cost * 1.33 + 10;
        }
        public double Price(ToyItem item)
        {
            if (item.Source == "Taiwan")
            {
                return item.Cost * 2.2;
            }
            else
            {
                return item.Cost * 1.5;
            }
        }
    }
