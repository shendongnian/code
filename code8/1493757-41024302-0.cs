     public static class Constants
        {
            public static class Roles
            {
                public const string Admin = "Admin";
                public const string User = "User";
            }
    
        }
    [Authorize(Roles=Constants.Roles.Admin)]
