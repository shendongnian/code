    public class Pay
    {
        private static double _HEALTH_INS { get; set; }
        
        public double HEALTH_INS { get { return _HEALTH_INS; } }
        public string WorkerName { get; set; }
        public double HoursWorked { get; set; }
        public double RateOfPay { get; set; }
    
        private double HealthIns
        {
            get
            {
                return Math.Round((HEALTH_INS * HoursWorked * RateOfPay), 2, MidpointRounding.AwayFromZero);
            }
        }
        
        public Pay(double rateOfPay) {
            var insuranceRepo = new InsuranceMultipliersRepository();
            this.RateOfPay = rateOfPay;
            this._HEALTH_INS = insuranceRepo.GetHealthMultiplier(rateOfPay);
        }
    }
