    public class Pay
    {
        private static readonly IHealthInsuranceRepository _insuranceRepo { get; }        
        public string WorkerName { get; set; }
        public double HoursWorked { get; set; }
        public double RateOfPay { get; set; }
    
        private double HealthMultiplier { get { return _insuranceRepo.GetHealthMultiplier(RateOfPay); } }
        private double HealthIns
        {
            get
            {
                return Math.Round((HealthMultiplier * HoursWorked * RateOfPay), 2, MidpointRounding.AwayFromZero);
            }
        }
        
        public Pay(double rateOfPay, IHealthInsuranceRepository healthInsuranceRepository) {
            _insuranceRepo = healthInsuranceRepository;
            this.RateOfPay = rateOfPay;
        }
    }
