    var currentUser = db.Users.Find(System.Web.HttpContext.Current.User.Identity.GetUserId());
    
    var entityInstance = new MyEntity();
    
    entityInstance.Id = Guid.NewGuid();
    
    entityInstance.AssociatedUsers.Add(currentUser);
    db.MyEntities.Add(entityInstance);
    db.SaveChanges();
