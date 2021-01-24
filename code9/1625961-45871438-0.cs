    if (activity.Type == ActivityTypes.Message)
    {
        if (activity.Text.StartsWith("/start"))
        {
            //This will return you the start parameter of a link like : http://telegram.me/botname?start=Parameter
            var Parameter = activity.Text.Replace("/start ", "");
        }
    }
