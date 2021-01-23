    DataAccess.User user = db.Users.SingleOrDefault(...);
    if (user == null)
    {
        // show error page telling that the POSTed email address is not known
    }
    ManageViewModel user_to_update = new ManageViewModel 
    {
        FirstName = user.FirstName,
        LastName = user.LastName,
        // ...
    }
    return View(user_to_update);
