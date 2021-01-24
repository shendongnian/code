    if (updateStatus)
    {
        paramList.Add(encryptedToken);
        var emailModel = Utility.CreateEmailModel(user.Email, paramList, AppConstants.RegistrationTemplateId, (int)EmailType.Register);
        await Helper.SendEmail(emailModel);
        
    }
