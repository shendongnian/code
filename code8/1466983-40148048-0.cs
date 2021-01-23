    DataAccess.User user = db.Users.SingleOrDefault(...);
    ManageViewModel user_to_update = new ManageViewModel 
    {
        FirstName = user.FirstName,
        LastName = user.LastName,
        // ...
    }
    return View(user_to_update);
