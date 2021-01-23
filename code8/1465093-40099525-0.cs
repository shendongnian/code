    // *************************
    // Log to Database
    // *************************
    // Instantiate the BotData dbContext
    Models.BotDataEntities DB = new Models.BotDataEntities();
    // Create a new UserLog object
    Models.UserLog NewUserLog = new Models.UserLog();
    // Set the properties on the UserLog object
    NewUserLog.Channel = activity.ChannelId;
    NewUserLog.UserID = activity.From.Id;
    NewUserLog.UserName = activity.From.Name;
    NewUserLog.created = DateTime.UtcNow;
    NewUserLog.Message = activity.Text.Truncate(500);
    // Add the UserLog object to UserLogs
    DB.UserLogs.Add(NewUserLog);
    // Save the changes to the database
    DB.SaveChanges();
