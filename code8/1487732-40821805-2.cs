    public Task StartTask(string TaskName, string optionalUri= "no_uri_passed")
    {
        if (TaskName == "FileInfo")
        {
            //Need to use a lamba expression to call a delegate with a parameter
            if (!(optionalUri == "no_uri_passed"))
            {
                return GetWowAuctionFileInfo(optionalUri) // this will return Task
            }
        }
    }
