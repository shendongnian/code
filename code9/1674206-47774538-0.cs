    public class CalculatedHours
    {
        public int EmployeeId { get; set; }
        public TimeSpan TimeToPay { get; set; }
    }
    public class PayTime
    {
        public DateTime PayTimeIn { get; set; }
        public DateTime PayTimeOut { get; set; }
        public int EmployeeId { get; set; }
        public TimeSpan CalculateTimeToPay(DateTime payrollWeekStart, DateTime payrollWeekEnd)
        {
            DateTime realIn = payrollWeekStart > this.PayTimeIn ? payrollWeekStart : this.PayTimeIn;
            DateTime realOut = payrollWeekEnd < this.PayTimeOut ? payrollWeekEnd : this.PayTimeOut;
            return realOut - realIn;
        }
        public static void Test()
        {
            List<PayTime> someData = new List<PayTime>() { };
                
            DateTime payrollWeekEnd = Convert.ToDateTime("2017-01-22");
            DateTime payrollWeekStart = Convert.ToDateTime("2017-01-16");
            IEnumerable<CalculatedHours> result = someData.GroupBy(g => g.EmployeeId)
                .Select(s => new CalculatedHours() { EmployeeId = s.Key, TimeToPay = new TimeSpan(s.Sum(a => a.CalculateTimeToPay(payrollWeekStart, payrollWeekEnd).Ticks)) });
        }
    }
