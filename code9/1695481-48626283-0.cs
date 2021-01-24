    using System;
    
    
    class DbContextOptionBuilder
    {
        public string ConnectionString { get; set; }
        public override string ToString() => $"ConnectionString: {ConnectionString}";
    }
    
    class ServiceCollection
    {
        public void AddDbContext(Action<DbContextOptionBuilder> job)
        {
            DbContextOptionBuilder o = new DbContextOptionBuilder { ConnectionString = "Empty" };
            job?.Invoke(o);
            Console.WriteLine(o);
        }
    }
    
    class Program
    {
        static void Wrong(DbContextOptionBuilder o)
        {
            o = new DbContextOptionBuilder { ConnectionString = "SQLITE" };
        }
    
        static void Correct(DbContextOptionBuilder o)
        {
            o.ConnectionString = "SQLITE";
        }
    
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext(Wrong);
            services.AddDbContext(Correct);
        }
    }
