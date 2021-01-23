    public class Dealer1 : DealerBase
    {
        public Dealer1() : base("DealerOne") { }
        public override void UpdatePrice()
        {
            //Calculate price
            Price = DealerOneCalculationMethod();
        } 
    }
    public class Dealer2 : DealerBase
    {
        public Dealer2() : base("DealerTwo") { }
        public override void UpdatePrice()
        {
            //Calculate price
            Price = DealerTwoCalculationMethod();
        } 
    }
