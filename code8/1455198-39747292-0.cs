        static void Main(string[] args)
        {
            var runtimeString = "Folder1.MyClass";
            IClass instanceOfMyClass = (IClass)CreateInstance(runtimeString);
            instanceOfMyClass.PrintMe();
            Console.ReadKey();
        }
        private static object CreateInstance(string className)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes()
                .First(t => t.FullName.EndsWith(className));
            return Activator.CreateInstance(type);
        }
