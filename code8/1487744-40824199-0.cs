    if (activity.Attachments != null && 
        activity.Attachments.Any() && 
        activity.Attachments.First().ContentType.Contains("image")) {
        //...
    }
