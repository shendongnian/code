        public RunsController()
        {
            //default is Ssl3
            string SecurityProtocolTypeFromConfig = System.Configuration.ConfigurationManager.AppSettings["SecurityProtocolType"];
            SecurityProtocolType fromConfig;
            Enum.TryParse(SecurityProtocolTypeFromConfig, out fromConfig);
            ServicePointManager.SecurityProtocol = fromConfig;
        }
