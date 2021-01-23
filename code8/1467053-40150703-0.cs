      NameValueCollection appSettings = ConfigurationManager.AppSettings;
    string isDebug = appSettings["IsDebug"]);
    if(isDebug == "True")
    {
    // your debug version message
    }
    then
    {
    // your release version message
    }
