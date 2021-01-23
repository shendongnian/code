    public class ConnectionStringSettings
    {
        public readonly string ConnectionString;
        public ConnectionStringSettings(string connectionString) {
            this.ConnectionString = connectionString;
        }
    }
    container.RegisterSingleton(new ConnectionStringSettings("constr"));
    container.Register(typeof(IRepository<>), typeof(Repository<>));
