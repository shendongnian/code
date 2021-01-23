    public class HomeController : Controller
        {
            //
            // GET: /Home/
            Model model = new Model();
            /* Holder */
            //public static Employee tmpEmp = new Employee();
            public ActionResult Index()
            {
                /* Holder */
                // var emp = tmpEmp; 
                Employee emp = (Employee) TempData["emp"];
                if (emp.Machines == null)
                {
                    emp.Machines = model.GenerateMatrix(5, 5);
                }
                return View(emp);
            }
    
            public ActionResult TransposeMatrix(Employee emp)
            {
                emp.Machines = model.TransposeMatrix(emp.Machines);
                /* Holder */
                // var tmpEmp = emp; 
                TempData["emp"] = emp;
                return RedirectToAction("Index");
            }
        }
