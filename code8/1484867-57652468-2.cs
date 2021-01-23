     public JsonResult TestAction()
        {
            if (null == Session["EmpId"]) 
              {
                logoutJson(); //Just call the function 
              }
        }
