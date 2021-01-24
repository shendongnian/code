    public class Pay
    {
        private static double HEALTH_INS { get; }
    
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
            this.HEALTH_INS = insuranceRepo.GetHealthMultiplier(rateOfPay);
        }
    }
