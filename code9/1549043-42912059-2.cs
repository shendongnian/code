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
        
        public Pay() {
        // This is a parameterless constructor. C# compiler actually generates this for you behind the scenes and sets every value to the default for its type. We're basically saying "use this instead of default one when creating an object" and providing additional instructions. In our case, the instruction would be retrieving the multiplier from the repository and storing it within the Pay class property.
    
            var insuranceRepo = new InsuranceMultipliersRepository();
    
            this.HEALTH_INS = insuranceRepo.GetHealthMultiplier(RateOfPay);
        }
    }
