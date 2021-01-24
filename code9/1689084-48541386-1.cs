    public async Task<User> CreateUser(GraphServiceClient graphClient)
    {
        // This snippet gets the tenant domain from the Organization object to construct the user's email address.
        var organization = await graphClient.Organization.Request().GetAsync();
        var domain = organization.CurrentPage[0].VerifiedDomains.ElementAt(0).Name;
        // Add the user.
        var userEmail = "TestUser@" + domain;
        var mailNickname = userEmail.Split(new char[] { '@' }).FirstOrDefault();
        return await graphClient.Users.Request().AddAsync(new User
        {
            AccountEnabled = true,
            DisplayName = "Test User",
            MailNickname = mailNickname,
            PasswordProfile = new PasswordProfile
            {
                Password = "super_strong_password"
            },
            UserPrincipalName = userEmail
        });
    }
