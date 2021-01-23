    User user_to_update = db.Users.SingleOrDefault(s => s.email == manageviewmodel.Email);
        
        if (user != null)
        {
        	var manageViewModel = new ManageViewModel()
        
        	manageViewModel.FirstName = user.FirstName;
        	manageViewModel.LastName = user.LastName;
        }
        else {
         //Manage null exception here
        }
            
