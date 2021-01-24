    public bool ValidateCredentials(string username, string password)
    {
        using (var principalcontext = new PrincipalContext(ContextType.Domain))
        {
            return principalContext.ValidateCredentials(username, password);
        }
    }
