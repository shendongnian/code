    User userLogin = User.Login<User>(username, password, ConnectionString, LogFile);
    if (userLogin != null)
        return InitiateToken(userLogin, sourceApp, sourceAddress, userIpAddress);
    else//Check it's LDAP path
    {
        User user = new User(ConnectionString, LogFile).GetUser(username);
        if (user != null && user.ExternalPath != null)
        {
            LDAPSpecification spec = new LDAPSpecification
            {
                UserName = username,
                Password = password,
                Path = user.ExternalPath.Path,
                Domain = user.ExternalPath.Domain
            };
            bool isAthenticatedOnLDAP = LDAPAuthenticateUser(spec);
    
        }
    }
