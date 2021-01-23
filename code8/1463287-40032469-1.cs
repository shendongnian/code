    public ActionResult Dashboard()
    {
        //first work out the customer type statistics
        List<Customer> customers = (from c in db.Customers where c.IsDeleted == false select c).ToList();
    
        CustomerType allCustomers = new CustomerType();
        allCustomers.CustomerTypeDescription = "Total Customers";
        allCustomers.CustomerCount = customers.Count;
    
        CustomerType existingCustomers = new CustomerType();
        existingCustomers.CustomerTypeDescription = "Existing Customers";
    
        CustomerType potentialCustomers = new CustomerType();
        potentialCustomers.CustomerTypeDescription = "Potential Customers";
    
        CustomerType newCustomers = new CustomerType();
        newCustomers.CustomerTypeDescription = "New Customers";
    
    
        foreach (cus in customers)
        {
            var ordercount = (from oc in db.SalesOrders where oc.CustomerID == cus.CustomerID && oc.CreatedDate >= cus.CreatedDate && oc.CreatedDate <= DateTime.Now.Date select oc.SalesOrderID).Count();
            if (ordercount >= 3)
            {
              existingCustomers.CustomerCount++;
            }
            else if (ordercount == 2 || ordercount == 1)
            {
              potentialCustomers.CustomerCount++;
            }
            else if (ordercount <= 0)
            {
              newCustomers.CustomerCount++;
            }
        }
    
        //now get the list of visits
        var userID = System.Web.HttpContext.Current.Session["UserID"].ToString();
        var currentUser = db.UserRightsSettings.Where(u => u.UserID.ToString() == userID).Select(e => new
        {
            employeeID = e.EmployeeID,
            departmentID = e.DepartmentID,
            usertypeID = e.UserTypeID
        }).FirstOrDefault();
        List<View_VisitorsForm> visitList = new List<View_VisitorsForm>();
        if (currentUser.departmentID == new Guid("47D2C992-1CB6-44AA-91CA-6AA3C338447E") &&
           (currentUser.usertypeID == new Guid("106D02CC-7DC2-42BF-AC6F-D683ADDC1824") ||
           (currentUser.usertypeID == new Guid("B3728982-0016-4562-BF73-E9B8B99BD501")))
        {
            visitList = db.View_VisitorsForm.Where(X => X.NextAppointment == DateTime.Now.Date).ToList();
        }
        else
        {
            visitList = db.View_VisitorsForm.Where(x => x.NextAppointment == DateTime.Now.Date && x.EmployeeID == currentUser.employeeID).ToList();
        }
        //finally bring it all together to create the ViewModel
        DashboardViewModel vm = new DashboardViewModel();
        vm.CustomerTypes.Add(allCustomers);
        vm.CustomerTypes.Add(existingCustomers);
        vm.CustomerTypes.Add(potentialCustomers);
        vm.CustomerTypes.Add(newCustomers);
        vm.Visits = visitList;
    
        return View("Dashboard", vm);
    }
