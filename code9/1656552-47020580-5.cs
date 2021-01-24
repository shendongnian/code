    [CustomHandleErrorAttribute]
    public ActionResult LoadEmployeeNames()
    {
        string ManageRSVPApplicationName =
        ConfigurationManager.AppSettings["ManageRSVPApplicationName"];
        Log log = new Log(ManageRSVPApplicationName);
    
        int applicationId = Convert.ToInt32(ControllerContext.HttpContext.Session["ApplicationId"]);
        Application application = new Application();
        application.ApplicationId = applicationId;
        if (DataBase.PopulateInviteeList(ref application, ref log))
        {
            List<EmployeeDropDownOption> employees = new List<EmployeeDropDownOption>();
            if (false)
            //if (EmployeeData.LoadEmployees(ref employees, application.InviteeList, ref log))
            {
                string currUserAccountName = User.Identity.Name.Split('\\')[1];
                EmployeeDropDownOption currEmployee = employees.FirstOrDefault(t => t.AccountName.Trim().ToLower() == currUserAccountName.Trim().ToLower());
                ViewBag.CurrentUserIdentity = (currEmployee == null) ? "" : currEmployee.EmployeeID.ToString() + ":" + currEmployee.DisplayName;
                int currOfficeId = 0;
                if (currEmployee != null)
                {
                    DataBase.GetOfficeId(currEmployee.Office, ref currOfficeId, ref log);
                    if (string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["TestOffice"]))
                    {
                        ControllerContext.HttpContext.Session["CurrentOffice"] = currEmployee.Office;
                    }
                    else
                    {
                        ControllerContext.HttpContext.Session["CurrentOffice"] = ConfigurationManager.AppSettings["TestOffice"];
                    }
    
                }
    
                ControllerContext.HttpContext.Session["CurrentOfficeId"] = currOfficeId;
    
                EmployeeDropDown employeeNameDD = new EmployeeDropDown(employees);
    
                return PartialView("~/Views/RSVP/RSVP/SelectEmployeeName.cshtml", employeeNameDD);
            }
    
        }
        log.Capture(Log.LogLevel.Error, "Unable to load employees when " + User.Identity.Name + " attempted to view RSVP application " + applicationId);
        return View("~/Views/ErrorHandler/Index.cshtml");
    
    
    }
