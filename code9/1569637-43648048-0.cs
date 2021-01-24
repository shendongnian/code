    var pattern = @"(?<=[a-z])(?=[A-Z])|(?<=[A-Z])(?=[A-Z][a-z])|(?<=[a-z])(?=[0-9])";
    Regex.Split("2FAGetDatabase", pattern);
    //2FA Get Database
    Regex.Split("Get2FADatabase", pattern);
    //Get 2FA Database
    Regex.Split("GetDatabase2FA", pattern);
    //Get Database 2FA
    Regex.Split("GetIDEDatabase2FA", pattern);
    //Get IDE Database 2FA
