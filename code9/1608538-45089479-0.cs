    public class EmployeeController : Controller
    {
        public PartialViewResultIndex()
        {
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.employeeName = "Jack";
            evm.employeeCity = "Los Angeles";
            evm.time = DateTime.Now.ToString();
            return PartialView("Employee", evm);
        }
    }
