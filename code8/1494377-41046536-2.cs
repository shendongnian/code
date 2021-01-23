      public static UserInfo GetDisplayName(string name)
        {
            using (UserPrincipal user = UserPrincipal.FindByIdentity(new PrincipalContext(ContextType.Domain), name))
            {
                if (user != null)
                {
                    return new UserInfo
                    {
                        FullName = user.DisplayName,
                        Email = user.EmailAddress,
                        GivenName = user.GivenName,
                        SamAccountName = user.SamAccountName,
                        Surname = user.Surname
                        //any other things you may need somewhere else
                    };
                }
                throw new Exception("error");
            }          
        }
