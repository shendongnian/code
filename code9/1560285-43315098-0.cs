    public class wages
    {
        const decimal HOURLY_RATE = 2.5M;
        const decimal MAX_FEE = 20.00M;
        private int _WorkingHour;
    
        public int WorkingHour
        {
            get { return _WorkingHour; }
            set
            {
                _WorkingHour = value;
                _AmountToPay = Math.Min(value * HOURLY_RATE, MAX_FEE);
            }
        }
        private decimal _AmountToPay;
    
        public decimal AmountToPay
        {
            get { return _AmountToPay; }
        }
    
        public override string ToString()
        {
            return String.Format("{0,4} {1,10}", WorkingHour, AmountToPay.ToString("C"));
        }
    }
