        public class EmployeeController : Controller
            {
                public ActionResult Index()
                {
                    return View("Employee",new EmployeeViewModel());
                }
                [HttpPost]
                public ActionResult AddEmp(EmployeeViewModel employee)
        
                {
        
                    var idOfEmployee=AddEmployee(employee);
        
                    foreach (var item in employee.SelectedSkills)
                    {
                        AddSkill(idOfEmployee,item);
                    }
                  
        
                    return View("Employee");
                }
           private void AddSkill(int idOfEmployee, int skillId)
            {
                // your EF logic
            }
    
            private int AddEmployee(EmployeeViewModel emp)
            {
                // your EF logic, get your id of the inserted employee
                return 0;
            }
         }
