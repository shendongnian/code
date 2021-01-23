    public interface IService { }
    public class Service : IService
    {
        public Service(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; set; }
    }
