     public ActionResult Index()
     {
        List<Department> departments = aDepartmentManager.GetAllDepartments(); //Get department details and keep it in a List<>
        if (ViewBag.Department != null)
        {
            ViewBag.Department = departments; //Assign the departments in ViewBag
        }
        return View();
     }
