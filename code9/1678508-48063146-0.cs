    public async Task<IntegrationRuntimeResource> CreateorUpdateIntegrationRuntime(string irmName)
            {
                Log.Information("Creating IntegrationRuntime Resource with name {IrmName}", irmName);
                var irmResource = new IntegrationRuntimeResource(new SelfHostedIntegrationRuntime(),
                    type: IntegrationRuntimeType.SelfHosted, // this is ignored by the API but persisted for my sanity (or an api upgrade)
                    name: irmName);
                return await AzureServiceFactory.GetDatafactoryManagementClient().IntegrationRuntimes
                    .CreateOrUpdateAsync(Config.ResourceGroupName, EnvironmentSettings.Datafactory.Name,
                        irmName, irmResource);
            }
 
