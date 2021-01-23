    public class PriceCalculator
    {
        public double Price(WomensFashionItem item) => item.Cost * 1.2;
        public double Price(MensFashionItem item) => item.Cost * 1.33 + 10;
        public double Price(ToyItem item) => item.Source == "Taiwan" ? item.Cost * 2.2 : item.Cost * 1.5;
    }
