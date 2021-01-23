    public class Dealer1ViewModel : DealerViewModelBase
    {
        public Dealer1ViewModel() : base("DealerOne") { }
        public override void UpdatePrice()
        {
            //Calculate price
            Price = DealerOneCalculationMethod();
        } 
    }
    public class Dealer2ViewModel : DealerViewModelBase
    {
        public Dealer2ViewModel() : base("DealerTwo") { }
        public override void UpdatePrice()
        {
            //Calculate price
            Price = DealerTwoCalculationMethod();
        } 
    }
