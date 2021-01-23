    [AutomaticRetry(Attempts = 5)]
    public static void NotifyRegistration(string userId, string username, string email, EmailService emailService)
    {
        //I calculate callbackUrl
        var emailToSend = new NewRegisteredUserEmail
        {
            To = email, UserName = username, CallbackUrl = callbackUrl 
        };
        emailService.Send(emailToSend);
    }
