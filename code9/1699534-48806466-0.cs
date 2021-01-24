    using(var db = new DatabaseEntities())
    {
        var user = UserManager.FindByIdAsync(User.Identity.GetUserId()).Result;
        var item = new Item();
        if (check)
            user.Items.Add(item);   
        else
            user.Items.Remove(item);
        
        
        db.SaveChanges();
    }
