    [ActionName("CreateNewEmployeeForm")]
    [HttpPost]
    public ActionResult SaveEmployee(EmployeeViewModel employee, string btnSubmit)
    {
        if (ModelState.IsValid)
        {
            switch (btnSubmit)
            {
                case "Save Employee":
                    ViewBag.Message = "Thanks! We got your information.";
                ... where you want to send them after they submit their data
                    break;
                case "Cancel":
                ... where you want to send them if they cancel (maybe back to the beginning)
                    break;
            }
        }
        return View();
    }
