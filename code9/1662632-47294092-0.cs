    public class Worker
    {
        // properties contain data for each worker
        public string Name { get; set; }
        public decimal HoursPerWeek { get; set; }
        public decimal HourlyPay { get; set; }
    
        // this is your constructor.  Set your variables to initial values here
        public Worker(string WorkerName, decimal WorkerHoursPerWeek, decimal WorkerHourlyPay)
        {
            this.Name = WorkerName;
            this.HoursPerWeek = WorkerHoursPerWeek;
            this.HourlyPay = WorkerHourlyPay;
        }
    
        // use methods to return any calculated values
        public decimal GetWeeklyPay()
        {
            decimal NormalHours;
    
            if (HoursPerWeek <= 40.0)
                NormalHours = HoursPerWeek;
            else
                NormalHours = 40.0M;
    
            decimal OverTimeHours;
    
            if (HoursPerWeek <= 40.0)
                OverTimeHours = 0.0M;
            else
                OverTimeHours = HoursPerWeek - 40.0;
    
            // hourly pay up to 40 hours, 1.5 times hourly pay for overtime
            return (NormalHours * HourlyPay) + (1.5M * (OverTimeHours * HourlyPay));
        }
    }
