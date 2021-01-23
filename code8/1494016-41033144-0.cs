    //CodeBase is the location of the ClickOnce deployment files
    Uri uriCodeBase = new Uri(assemblyInfo.CodeBase);
    string ClickOnceLocation = Path.GetDirectoryName(uriCodeBase.LocalPath.ToString());
    if(ClickOnceLocation.Contains("Debug"))
    {
        URL = "http://localhost";    
    }
    else
    {
        URL = //from app.config
    }
