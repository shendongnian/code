    // Get the existing student from the db
    var user = (Student)UserManager.FindById(model.Id);
    
    // Update it with the values from the view model
    user.Name = model.Name;
    user.Surname = model.Surname;
    user.UserName = model.UserName;
    user.Email = model.Email;
    user.PhoneNumber = model.PhoneNumber;
    user.Number = model.Number; //custom property
    user.PasswordHash = checkUser.PasswordHash;
    
    // Apply the changes if any to the db
    UserManager.Update(user);
