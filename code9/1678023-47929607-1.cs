    public class ConfigurationSelectorQueryServiceProxy : IQueryService
    {
        private readonly IQueryService a;
        private readonly IQueryService b;
        private readonly IQueryService c;
        public ConfigurationSelectorQueryServiceProxy(
            SqlQueryService a, NCRFileQueryService b, FileQueryService c) {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        // IQueryService methods. Forward the call to one of the wrapped services
        public object SomeMethod(object args) => GetService().SomeMethod(args);
        
        // Helper methods
        private IQueryService GetService() =>
            // Read configuration value
            GetService(_configuration.SelectedTPV.Connection);
        
        private IQueryService GetService(string value) =>
            value == "Data Source" ? (this.a :
            value == "NCR File Source ? this.b :
            value == "File Source" ? this.c :
            throw new InvalidOperationException(value);        
    }
