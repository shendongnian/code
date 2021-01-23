           private readonly EnvironmentData _environmentData;
           public Api(EnvironmentData envData)
           {
                environmentData = envData;
           }
           public string GetCulture()
           {
                return _envData.GetCulture();                   
           }
     }
