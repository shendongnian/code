            bool _isValid;
            username = "YourDomain\\" + username;
            using (var pc = new PrincipalContext(ContextType.Machine))
            {
                isValid = pc.ValidateCredentials(username, password, ContextOptions.Negotiate);
            }
