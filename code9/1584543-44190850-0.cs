    public static class UserManagerExtension
    {
                public static Task SendEmailAsync(this UserManager manager, 
            TKey userId, string subject, string body, string extraParameter)
                {
                            //Do something with parameter
                            return manager.SendEmailAsync(userId, subject, body);
                }
    }
