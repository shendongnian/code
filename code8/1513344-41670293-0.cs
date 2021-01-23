    public class EmployeeController : Controller
    {
        // Employee/Index/1
        public ActionResult Index(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employee = employeeContext.Employees.Where(emp => emp.DepartmentId == departmentId).ToList();
            return View(employee);
        }
    }
