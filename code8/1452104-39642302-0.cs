    if(e.Message.MentionedUsers.FirstOrDefault().HasKickPermission())
    {
         // process kick
    }
    else
    {
        // show message the processing is not allowed
    }
