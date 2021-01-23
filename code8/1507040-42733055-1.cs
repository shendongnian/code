      protected void Application_Start(object sender, EventArgs e)
        {
           GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();  //This will remove XML serialization and return everything in JSON.
            GlobalConfiguration.Configuration.MapHttpAttributeRoutes();
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
