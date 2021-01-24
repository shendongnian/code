            GlobalConfiguration.Configuration.Formatters.Clear(); // or remove just the json one 
            var jsonformatter = new System.Net.Http.Formatting.JsonMediaTypeFormatter()
            {
                SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings()
                {
                    // all your configurations
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All
                }
            };
            GlobalConfiguration.Configuration.Formatters.Add(jsonformatter);
