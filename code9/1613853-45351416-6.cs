    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create( Userviewmodel usermodel, string[] yearList,string[] monthList,string[] dayList())
    {
        if (ModelState.IsValid)
        {
          
            user model=new user()
            model.TicketType=.usermodel.TicketType;
            model.FirstName=usermodel.FirstName;
            model.LastName=usermodel.LastName;
            model.Gender=usermodel.Gender;
            
           for(int i=0;i<yearlist.count();i++)
           {
             History child=new History()  
             child.Year=yearlist[i].Year;
             child.month=montList[i].month;
             chile.day=dayList[i].day;            
             model.Histories.add(child);  
           }                      
            db.Users.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(user);
    }
