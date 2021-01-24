    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create( Userviewmodel usermodel)
    {
        if (ModelState.IsValid)
        {
          
            user model=new user()
            model.TicketType=.usermodel.TicketType;
            model.FirstName=usermodel.FirstName;
            model.LastName=usermodel.LastName;
            model.Gender=usermodel.Gender;
            
             History child=new History()  
           child.Year=usermodel.Year;
           child.month=usermodel.month;
           chile.day=usermodel.day;
            
           model.Histories.add(child);                        
            db.Users.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(user);
    }
