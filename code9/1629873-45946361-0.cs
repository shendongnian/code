         public ActionResult Delete(string UserName)
        {
    var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
    
            var user = userManager.FindByName(UserName);
           
            _context.UserLogs
               .Where(p => p.Customer.Id == user.Id)
               .ToList()
               .ForEach(p => _context.UserLogs.Remove(p));
      
            _context.SaveChanges(); 
            userManager.Delete(user);
            return RedirectToAction("Index");
        }
