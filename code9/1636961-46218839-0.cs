    public class Employee
    {
    }
    public interface ISalaryManager
    {
        void PaySalary(Employee e);
        bool HandlesPaymentType(string paymentType);
    }
    public class CashSalaryManager : ISalaryManager
    {
        public void PaySalary(Employee e)
        {
            var bankService = GetBankService();
            bankService.Pay(e);
        }
        public bool HandlesPaymentType(string paymentType)
        {
            return paymentType == "Cash";
        }
    }
    public class OnlineSalaryManager : ISalaryManager
    {
        public void PaySalary(Employee e)
        {
            // Different implementation
        }
        public bool HandlesPaymentType(string paymentType)
        {
            return paymentType == "Online";
        }
    }
    public class SalaryPaymentManager
    {
        private readonly IEnumerable<ISalaryManager> _salaryManagers;
        public SalaryPaymentManager(IEnumerable<ISalaryManager> salaryManagers)
        {
            _salaryManagers = salaryManagers;
        }
        public void PaySalary(string paymentType, Employee employee)
        {
            var salaryManager = _salaryManagers.FirstOrDefault(x => x.HandlesPaymentType(paymentType));
            if (salaryManager == null)
                throw new NotImplementedException();
            salaryManager.PaySalary(employee);
        }
    }
