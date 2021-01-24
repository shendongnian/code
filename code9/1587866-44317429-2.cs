    public class Data
    {
        public List<double> Payment { get; }
        public List<double> Interest { get; }
        public Data(List<double> payment, List<double> interest)
        {
            Payment = payment;
            Interest = interest;
        }
    }
