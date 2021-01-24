    public interface IMyServiceCollection
    {
        public IServiceCollection Services { get; set; }
    
        public IConfiguration Configuration { get; set; }
    }
    public static void AddFooModule(this IMyServiceCollection myServices)
    {
        var services = myServices.Services;
        var config = myServices.Configuration;
    }
