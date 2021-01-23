    private void RipMeGetLatestVersion_Process()
    {
        LatestRipMe = ClientRipMe.DownloadString("http://www.rarchives.com/ripme.json");
    
        LatestRipMeVersion = LatestRipMe.Split(Environment.NewLine.ToCharArray())[1];
        LatestRipMe = LatestRipMe.Trim("  \"latestVersion\" : \"\",".ToCharArray());
    
        LatestRipMeVersionText.Text = "Latest RipMe version: " + LatestRipMe;
    }
