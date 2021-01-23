    public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                Models.ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var account = new AccountController(HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(), null);
                ViewBag.RolesForThisUser = account.UserManager.GetRoles(user.Id);
                // prepopulate roles for the view dropdown
                var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = list;
            }
            return View("ManageUserRoles");
        }
