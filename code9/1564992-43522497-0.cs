     protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Error +=
                delegate(object sender, ErrorEventArgs args)
                {
                                       
                    File.WriteAllText(@"c:\\temp\\jsonerrortest.txt", args.ErrorContext.Error.Message);                                    
                    
                };   
        }
