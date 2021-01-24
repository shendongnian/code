    public class Pay
    {
        private static double HEALTH_INS = 0.07;
        
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
        // With latest versions of C# you could actually do this:
        private double HealthInsAlt =>  Math.Round((HEALTH_INS * grossPay), 2, MidpointRounding.AwayFromZero);
    }
