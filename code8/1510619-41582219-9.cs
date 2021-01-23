    // Email Sending
    UserData sampleData = new UserData();
    sampleData.Id = user.Id;
    sampleData.UserName = user.UserName;
    sampleData.UserEmail = user.Email;
    sampleData.FirstName = user.FirstName;
    sampleData.Password = model.Password;
    var confirmationEmailUrl = Url.Link("Default", new { Action = "ConfirmEmail", Controller = "Account",  Token = sampleData.Id, Email = sampleData.UserEmail });
    var emailService = new EmailService();
    var user = emailService.SendEmail(sampleData, confirmationEmailUrl);
   
