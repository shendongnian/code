    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, UserViewModel model)
    {
        var user = repository.GetById(id);
        if (ModelState.IsValid)
        {
           if (user != null)
           {
               user.Username = model.users.Username;
               user.Forename = model.users.Forename;
               user.Lastname = model.users.Lastname;
               user.Email = model.users.Email;
               user.Status = model.users.Status;
               user.UserRoleID = Convert.ToInt32(model.selectedRole);           
               db.Entry(user).State = EntityState.Modified;
               db.SaveChanges();
               return RedirectToAction("Index");
           }
           else
           {
               return View();
           }                
            return View();         
        }
