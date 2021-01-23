    [HttpGet]
     public ActionResult RoleAddToUser()
    {
            AssignRoleVM objvm = new AssignRoleVM(); 
            objvm.RolesList = GetAll_Roles();
            objvm.Userlist = GetAll_Users();
            return View(objvm);
    }
       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(AssignRoleVM objvm)
        {
           
            if (objvm.RoleName == "0")
            {
                ModelState.AddModelError("RoleName", "Please select RoleName");
            }
            if (objvm.UserId == "0")
            {
                ModelState.AddModelError("UserName", "Please select Username");
            }
            if (ModelState.IsValid)
            {
                
                var User = objvm.UserId;
                Roles.AddUserToRole(User, objvm.RoleName);
                ViewBag.ResultMessage = "Username added to the role successfully !";
                objvm.RolesList = GetAll_Roles();
                objvm.Userlist = GetAll_Users();
                return View(objvm);
            }
            else
            {
                objvm.RolesList = GetAll_Roles();
                objvm.Userlist = GetAll_Users();
            }
            return View(objvm);
        }
  
