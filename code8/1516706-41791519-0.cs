    public class EmployeeAdministrator()
    {
        public void addEmployee(){ some code };
    }
    public class SalaryAdministrator()
    {
        public void Salary_PaySlip() { some code };
    }
    public class HR 
    {
        public EmployeeAdministrator Administrator { get; }
        // make use of addEmployee()
    }
    class Accountant
    {
        public SalaryAdministrator Administrator { get; }
        // make use of void Salary_PaySlip()
    }
