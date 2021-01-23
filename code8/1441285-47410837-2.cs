    public class MyDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection services)
        {
            services.AddSingleton<IPluralizer, MyPluralizer>();
        }
    }
    
    public class MyPluralizer : IPluralizer
    {
        public string Pluralize(string name)
        {
            return Inflector.Inflector.Pluralize(name) ?? name;
        }
    
        public string Singularize(string name)
        {
            return Inflector.Inflector.Singularize(name) ?? name;
        }
    }
