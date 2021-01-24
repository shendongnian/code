        var user = new User { UserName = model.Email, Email = model.Email, RegisterDate = DateTime.Now };
        user.Id = Guid.NewGuid().ToString();
        var result = await UserManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {             
             await SendConfirmationEmail(user);
         
             return View("ConfirmationEmailSent");
        } 
     
      
