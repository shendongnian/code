    namespace MyProject
    {
        public class Bootstrap : DefaultNancyBootstrapper
        {
            protected override void ConfigureApplicationContainer(TinyIoCContainer container)
            {
                base.ConfigureApplicationContainer(container);
    
                container.Register<JsonSerializer, CustomJsonSerializer>();
            }
        }
    
        public class CustomJsonSerializer : JsonSerializer
        {
            public CustomJsonSerializer()
            {
                this.ContractResolver = new CamelCasePropertyNamesContractResolver();
                this.Formatting = Formatting.Indented;
            }
        }
    }
