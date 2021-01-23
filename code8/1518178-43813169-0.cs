    public class TheRegistery :StructureMap.Registry
    {
        public TheRegistery()
        {
            For<IMyInterface>().Use<YourClassName>();  // << This Syntax
            
            Scan(scanner =>
            {
                scanner.WithDefaultConventions();
                scanner.AssemblyContainingType<UserMailer>();
            });
        }
    }
