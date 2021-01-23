    // Email Sending
    UserData sampleData = new UserData();
    sampleData.Id = user.Id;
    sampleData.UserName = user.UserName;
    sampleData.UserEmail = user.Email;
    sampleData.FirstName = user.FirstName;
    sampleData.Password = model.Password;
    var confirmationEmailUrl = Url.Action("ConfirmEmail", "Account", new { Token = sampleData .Id, Email = sampleData .UserEmail }, Request.Url.Scheme));
    var emailService = new EmailService();
    var user = emailService.SendEmail(sampleData, confirmationEmailUrl);
    
    return View(user);
