    public class ConnectionStringSettings
    {
        public string ConnectionString {get;set;}
    }
    container.RegisterSingleton(new ConnectionStringSettings { ConnectionString = "constr" });
    container.Register(typeof(IRepository<>), typeof(Repository<>));
