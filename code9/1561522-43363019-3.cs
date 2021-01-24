    private ApplicationDbContext context = new ApplicationDbContext();
    // To view the List of User 
     public ActionResult ListUsers ()
            {
                return View(context.Users.ToList());
            }
    public ActionResult EditUser(string email)
            {
                ApplicationUser appUser = new ApplicationUser();
                appUser = UserManager.FindByEmail(email);
                UserEdit user = new UserEdit();
                user.Address = appUser.Address;
                user.FirstName = appUser.FirstName;
                user.LastName = appUser.LastName;
                user.EmailConfirmed = appUser.EmailConfirmed;
                user.Mobile = appUser.Mobile;
                user.City = appUser.City;
                
    
                return View(user);
            }
		
        [HttpPost]
        public async Task<ActionResult> EditUser(UserEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(store);
            var currentUser = manager.FindByEmail(model.Email);
            currentUser.FirstName = model.FirstName;
            currentUser.LastName = model.LastName;
            currentUser.Mobile = model.Mobile;
            currentUser.Address = model.Address;
            currentUser.City = model.City;
            currentUser.EmailConfirmed = model.EmailConfirmed;
            await manager.UpdateAsync(currentUser);
            var ctx = store.Context;
            ctx.SaveChanges();
            TempData["msg"] = "Profile Changes Saved !";
            return RedirectToAction("ListUser");
        }
