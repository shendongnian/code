    static Logger()
    {
        log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo
                                                (System.IO.Path.GetDirectoryName
                                                
        (System.Reflection.Assembly.GetExecutingAssembly().Location)));
    }
