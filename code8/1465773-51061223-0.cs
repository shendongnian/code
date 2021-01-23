    public class Lib1Module: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Console.WriteLine("Registering Lib1Module");
            // Register Types...
            
        }
    }
    public class Lib2Module: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Console.WriteLine("Registering Lib2Module");
            builder.RegisterModule<Lib1Module>();
            // Register Types...
            
        }
    }
    public class Lib3Module: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Console.WriteLine("Registering Lib3Module");
            builder.RegisterModule<Lib1Module>();
            // Register Types...
            
        }
    }
    public class Program
    {
        public void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<Lib2Module>();
            builder.RegisterModule<Lib3Module>();
            
            using(var container = builder.Build())
            {
                // Do Stuff
            }
        }
    }
