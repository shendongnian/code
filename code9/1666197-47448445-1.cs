        bool _isValid;
        using (var pc = new PrincipalContext(ContextType.Domain, DomainPath))
        {
            isValid = pc.ValidateCredentials(username, password, ContextOptions.Negotiate);
            if (!isValid)
            {
                var user = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, userName);
                if (user == null)
                {
                    //Username doesn't exist
                }
                else
                {
                    //Password is invalid
                }
            }
        }
