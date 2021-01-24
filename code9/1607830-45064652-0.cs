    private BrattleHubEntities officeInfo = new BrattleHubEntities();
    private BrattlecubesEntities empInfo = new BrattlecubesEntities();
    
            // GET: DimOffices
            public ActionResult Index()
            {
    
                string currentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                string currentUserLogin = currentUser.Substring(10);
                var employee = from e in empInfo.DimEmployees//Method 1 to pull current user
                               select e;
                employee = employee.Where(e => e.UserLogin.Contains(currentUser) && e.EmployeeOffice.Contains("BOS"));
    
                var employeeOfficeInfo = from t1 in officeInfo.DimOffices
                                         join t2 in empInfo on t1.OfficeCode equals t2.EmployeeOffice
                                         select new { t1.OfficeCode, t1.MainPhone, t1.MainFax };
    
                return View(employeeOfficeInfo);
            }
