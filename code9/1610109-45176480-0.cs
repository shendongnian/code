    public class CustomDesignTimeService : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
                    => serviceCollection.AddSingleton<IPluralizer, CustomPluralizer>();
    }
