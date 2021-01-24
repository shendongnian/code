    public class Worker
    {
        // Here the property is public, so you'd be able to do the following:
        // var contractor = new Worker("John");
        // string contractorName = contractor.WorkerName;
        public string WorkerName { get; }
        
        public Worker(string workerName)
        {
             this.WorkerName = workerName;
        }
    }
    public class Pay
    {
        private static double HEALTH_INS { get; }
        
        // Three properties below are private and are set in the constructor.
        // The "HoursWorked" has a setter because sometimes we need to add hours.
        // Others don't because we set them once when we create an object
        // You're NOT able to do:
        // var someWorkersPay = new Worker();
        // var someWorkersRate = someWorkersPay.RateOfPay;
        private string WorkerName { get; }
        private double HoursWorked { get; set; }
        private double RateOfPay { get; }
        
        public double GrossPay { get { return HoursWorked * RateOfPay; } }
        private double HealthIns
        {
            get
            {
                return Math.Round((HEALTH_INS * HoursWorked * RateOfPay), 2, MidpointRounding.AwayFromZero);
            }
        }
        
        public Pay(Worker workerWithPay, double hoursSpent, double payRate) {
            var insuranceRepo = new InsuranceMultipliersRepository();
            this.WorkerName = workerWithPay.WorkerName;
            this.HoursWorked = hoursSpent;
            this.RateOfPay = payRate;
            this._HEALTH_INS = insuranceRepo.GetHealthMultiplier(rateOfPay);
        }
        public void AddHoursWorked(double hoursToAdd) {
            this.HoursWorked += hoursToAdd;
        }
        public double GetRateOfPay() {
            return this.RateOfPay;
        }
        // Now you can do someWorkersPay.GetRateOfPay();
    }
