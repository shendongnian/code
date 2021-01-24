    static Program {
        public static void Main(string[] args) {
            var assembly = Assembly.Load(AssemblyLoadContext.GetAssemblyName(args[0]));
    
            foreach (var type in assembly.DefinedTypes)
                Console.WriteLine(type.FullName);
        }
    }
