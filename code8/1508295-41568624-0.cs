       public static async Task<ObservableCollection<string>> GetConfigurationHL7Server5Async()
            {
                IManagerListener client = Globals.factory.CreateChannel();
                return await client.GetConfigurationsAsync("interfacex");
            }
