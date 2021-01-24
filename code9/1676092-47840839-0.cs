    public class EmployeeController : Controller
        {
            // GET: Employee
            public ActionResult Index()
            {
               
                List<EmloyeeViewModel> emVM = new List<EmloyeeViewModel>();
                List<Employee> emp = new List<Employee>()
                {
                 new Employee(1, "Tony", "Cruise", 231.89),
                 new Employee(2, "Bill", "George", 152.11),
                 new Employee(3, "John", "Bill", 7651.29),
                 new Employee(4, "Donald", "Kay", 1500.08),
                 new Employee(5, "Smith", "Bill", 28.91),
                 new Employee(6, "Tirus", "Peter", 1128.91)
    
                 };
    
                foreach (Employee f in emp)
                {
                    EmloyeeViewModel em = new EmloyeeViewModel();
                    em.EmployeeID = f.EmployeeID;
                    em.FullName = f.FirstName + " " + f.LastName;
                    em.Salary = f.Salary.ToString("C");
                    if (f.Salary > 100)
                    {
                        em.salcolor = "green";
                    }
                    else
                    {
                        em.salcolor = "red";
                    }
                    emVM.Add(em);
    
                }
    
                return View(emVM);
            }
        }
