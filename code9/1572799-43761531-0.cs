    //get the path of the website
    string path = HttpContext.Current.Request.ApplicationPath;
    
    //create a webconfiguration instance
    System.Configuration.Configuration cfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(path);
    
    //add the new keyvalue to the web.config, remove the old one if necessary
    cfg.AppSettings.Settings.Remove("myAppKey");
    cfg.AppSettings.Settings.Add("myAppKey", "myAppValue");
    
    //save the new value
    cfg.Save();
