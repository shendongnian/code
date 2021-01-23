    [HttpGet]
    public ActionResult CreateOrEdit(int? id)
    {
         UserDTO user = null;
         if( id!=null)
             user = db.Users.Select(t=> new UserDTO {
                 UserName = t.UserName,
                 FirstName = t.Person.FirstName,
                 LastName = t.Person.LastName,
                 Id = t.Id
                 // ... //
             }).FirstOrDefault();
         else
             user = new UserDTO();
         return View(user);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateOrEdit(UserDTO model)
    {
          if(model!=null && ModelState.IsValid)
          {
               if(model.Id>0) // Edit
               {
                   User  user = db.Users.Include(p=>p.Person).Single(t=>t.Id == model.Id);
                   user.UserName = model.UserName;
                   user.Person.FirstName = model.FirstName;
                   user.Person.LastName = model.LastName;
               }
               else // Add
               {
                   User user = new User
                   {
                       UserName = model.UserName,
                       Password = model.Password, // should be encrypted first
                       Person = new Person{
                          FirstName = model.FirstName,
                          LastName = model.LastName
                       }
                   };
                   db.Users.Add(user);
               }
               db.SaveChanges();
               return RedirectoToAction("TargetActionGoesHere");
          }
          return View(model);
    }
