    endpointConfiguration.EnableFeature<MyFeature>();
    public class MyFeature : Feature
    {
        protected override void Setup(FeatureConfigurationContext context)
        {
            var endpointInstances = context.Settings.Get<EndpointInstances>();
            endpointInstances.AddOrReplaceInstances("InstanceMapping",
                new List<EndpointInstance>
                {
                    new EndpointInstance("MyEndpoint").AtMachine("VM-1")
                });
        }
    }
