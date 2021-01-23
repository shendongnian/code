    User user_to_update = db.Users.SingleOrDefault(s => s.email == manageviewmodel.Email);
    
    var manageViewModel = new ManageViewModel()
    manageViewModel.FirstName = user.FirstName;
    manageViewModel.LastName = user.LastName;
