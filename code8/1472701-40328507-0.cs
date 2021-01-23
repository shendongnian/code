        public ActionResult CreateRole()
        {
            NewRole newRole = new NewRole();
            return View(newRole);
        }
        [HttpPost]
        public ActionResult CreateRole(NewRole newRole)
        {
            string Output = "";
            ApplicationDbContext db = new ApplicationDbContext();
            RoleManager<IdentityRole> RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            if (!RoleManager.RoleExists("Admins"))
            {
                IdentityResult Result = RoleManager.Create(new IdentityRole(newRole.Name));
                if (Result.Succeeded)
                {
                    Output = "the role created";
                }
                else
                {
                    int ErrorCount = Result.Errors.Count();
                    Output = "Errors is: " + Result.Errors.ToList()[0];
                }
            }
            else
            {
                Output = "the roles exist";
            }
            
            if (Output == "")
            {
                ModelState.AddModelError(string.Empty, "tesssst");
                return View(newRole);
            }
            else
            {
                return Redirect("Suscces url");
            }
            
        }
