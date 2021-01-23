    Here I have created a controller named "HomeController"
    
            public ActionResult Index()
        {
            List<Employee> list = new List<Employee>();
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                list = dc.Employees.OrderBy(a => a.EmployeeID).ToList();
            }
            return View(list);
        }
