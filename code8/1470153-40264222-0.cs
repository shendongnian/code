        /// <summary>
        /// When calling from a T4 template, it seems you cannot use the ConfigurationManager.
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            var connectionString = string.Empty;
            if (ConfigurationManager.ConnectionStrings["DBContext"] != null)
            {
                connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
            }
            else if (System.Reflection.Assembly.GetExecutingAssembly().GetName().Name == "MyApplication")
            {
                ExeConfigurationFileMap configToUse = null;
                var possibleConfig = System.Reflection.Assembly.GetExecutingAssembly().Location + ".config";
                if (File.Exists(possibleConfig))
                {
                    configToUse = new ExeConfigurationFileMap();
                    configToUse.ExeConfigFilename = possibleConfig;
                    var config = ConfigurationManager.OpenMappedExeConfiguration(configToUse, ConfigurationUserLevel.None);
                    connectionString = config.ConnectionStrings.ConnectionStrings["DBContext"].ConnectionString;
                }
            }            
            return connectionString;
        }
