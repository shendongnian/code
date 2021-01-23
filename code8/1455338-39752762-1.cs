    var userSettings = new UserSettings()
    {
        SystemUserId = systemUserId, //user id
        TimeZoneCode = 105 //(GMT+01:00) Brussels, Copenhagen, Madrid, Paris
    };
    organizationService.Update(userSettings); 
