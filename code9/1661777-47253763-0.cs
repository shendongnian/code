    class EmployeeController : Controller
    {
        public ActionResult Identity(string employeeID)
        {
            if (employeeID == "BusinessOwner")
            {
                var businessOwnerController = new BusinessOwnerController();
                businessOwnerController.ControllerContext = new ControllerContext(
                    this.ControllerContext.RequestContext,
                    businessOwnerController
                );
                return businessOwnerController.Identity();
            }
            else
            {
                //Do employee stuff
            }
        }
    }
 
