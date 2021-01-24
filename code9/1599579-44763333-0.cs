    User newUser = new User
    {
        Id = user.Id,
        BusinessPhones = someUser.BusinessPhones,
        DisplayName = someUser.DisplayName,
        GivenName = someUser.GivenName,
        JobTitle = someUser.JobTitle,
        Mail = someUser.Mail,
        MobilePhone = someUser.MobilePhone,
        OfficeLocation = someUser.OfficeLocation,
        PreferredLanguage = someUser.PreferredLanguage,
        Surname = someUser.Surname,
        UserPrincipalName = someUser.UserPrincipalName
    };
    User createdUser = await graphClient.Users.Request().AddAsync(newUser);
