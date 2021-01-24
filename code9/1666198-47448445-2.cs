        bool _isValid;
        using (var pc = new PrincipalContext(ContextType.Domain, DomainPath))
        {
            isValid = pc.ValidateCredentials(username, password, ContextOptions.Negotiate);
            if (!isValid)
            {
                var user = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, username);
                if (user == null)
                {
                    //User doesn't exist
                }
                else
                {
                    //Password is invalid
                }
            }
        }
