    namespace EFCTTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var context = new MyContext();
                context.Tests.First().Test = "Edited";
    
                var models = context.ChangeTracker.Entries<TestModel>().Where(x => x.State == EntityState.Modified).ToList();
                foreach(var model in models)
                    Console.WriteLine($"From {model.OriginalValues["Test"]} to {model.CurrentValues["Test"]}");
    
                Console.ReadLine();
            }
        }
    
        public class MyContext : DbContext
        {
            public MyContext()
            {
                Configuration.ProxyCreationEnabled = false;
            }
    
            public DbSet<TestModel> Tests { get; set; }
        }
    
        public class TestModel
        {
            public int Id { get; set; }
            public string Test { get; set; }
        }
    }
