    using (ServerManager serverManager = new ServerManager())
    {
        Configuration configuration = serverManager.GetWebConfiguration("your website name");
        
        ConfigurationSection customErrorsSection = configuration.GetSection("system.web/customErrors");
        customErrorsSection.SetAttributeValue("defaultRedirect", "/your error page.htm");
        ConfigurationElementCollection errorsCollection = customErrorsSection.GetCollection();
        serverManager.CommitChanges();
    }
