    //Try to get already launched Ignite Instance
    IIgnite ignite = Ignition.TryGetIgnite(igniteName);
    while (ignite == null)
    {
        try
        {
            //Try to start Ignite
            ignite = Ignition.Start(igniteConfig);
        }
        catch (Exception) //If failing to start Ignite, wait a bit for the previous AppDomain to stop the Ignite running instance...
        {
            HttpRequest request = null;
            try
            {
                request = HttpContext.Current.Request;
            }
            catch { }
            //Check if there is a request coming from the same machine, if yes, cancel it.
            if (request == null || !(request.IsLocal || request.UserHostName.EndsWith("myhostname.com"))
                Thread.Sleep(1000);
            else
                throw new HttpException(500, "Server error. Server rebooting.");
        }
    }
    //Use ignite variable here...
