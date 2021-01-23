    Configuration rootWebConfig = 
        WebConfigurationManager.OpenWebConfiguration("~/");
    if(0<rootWebConfig.AppSettings.Settings.Count)
    {
        KeyValueConfigurationElement picRootElement = 
            rootWebConfig.AppSettings.Settings["PicRootPath"];
        if(null!=picRootElement)
        {
            _picRootPath=picRootElement.Value;
        }
    
        picRootElement = rootWebConfig.AppSettings.Settings["PicRootDefaultPath"];
        if (null != picRootElement)
        {
            _picRootDefaultPath = picRootElement.Value;
        }
    }
