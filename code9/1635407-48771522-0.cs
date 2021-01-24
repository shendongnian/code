    namespace WebApplication1.Models
    {
        public class Employee
        {
            public decimal Salary { get; set; }
            public string SalaryUS
            {
                get { return string.Format(new System.Globalization.CultureInfo("en-US"), "{0:C}", Salary); }
            }
            public string SalaryPL
            {
                get { return string.Format(new System.Globalization.CultureInfo("pl-PL"), "{0:C}", Salary); }
            }
        }
    }
