    public ActionResult GetEmployees()
            {
                ...
                return Content(js.Serialize(employees), "application/json"); 
            }
