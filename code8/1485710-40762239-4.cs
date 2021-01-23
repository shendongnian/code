    class Program
    {
        public static IContainer _container;
        static void Main(string[] args)
        {
            //Register types
            Register();
            //Resolve a dog
            var dog = _container.ResolveKeyed<IAnimal>("Dog");
            //Resolve a cat
            var cat = _container.ResolveKeyed<IAnimal>("Cat");
            dog.Bark(); //Bow Bow
            cat.Bark(); //Meow Meow
            Console.Read();
       }
        static void Register()
        {
            //Get all types implementing IAnimal, you can of course scan multiple assemblies,
            //here I am only looking at the current assembly
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => !t.IsInterface && t.IsAssignableTo<IAnimal>());
            var builder = new ContainerBuilder();
            foreach (var t in types)
            {
                //Use the type name as a key to the instance
                builder.RegisterType(t).Keyed<IAnimal>(t.Name)
                  .InstancePerDependency(); //You want a new instance each time you resolve
            }          
                      
            _container = builder.Build();            
        }
    }
