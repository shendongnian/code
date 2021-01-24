    public void Customize(BusConfiguration configuration)
        {
            var endpointName = typeof(EndpointConfig).Namespace;
            configuration.UniquelyIdentifyRunningInstance().UsingCustomIdentifier(endpointName);
            configuration.EnableOutbox();
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.Transactions().DefaultTimeout(TimeSpan.FromMinutes(5.0));
            configuration.UseSerialization<JsonSerializer>();
            
            configuration.Conventions()
                .DefiningCommandsAs(type => typeof(ICustomCommand).IsAssignableFrom(type));
            configuration.EnableDurableMessages();
            configuration.EnableInstallers();
            var container = ContainerInitializer.Container;
            configuration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(container));
        }
