    static void Main()
    {
        var methods = AppDomain.CurrentDomain.GetAssemblies()
                        //Get a sequence of all types in the referenced assemblies
                        .SelectMany(assembly => assembly.GetTypes()) 
                        //Get a sequence of all the methods in those types. 
                        //The BindingFlags are needed to make sure both public and non-public instance methods are included. 
                        //Otherwise private methods are skipped.
                        .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                        //And finally, filter to only those methods that have someAttribute attached to them
                        .Where(method => Attribute.IsDefined(method, typeof(someAttribute)));
        foreach (MethodInfo methodInfo in methods)
        {
            IEnumerable<someAttribute> SomeAttributes = methodInfo.GetCustomAttributes<someAttribute>();
            foreach (var attr in SomeAttributes)
            {
                //Here, you can create the file.
                Console.WriteLine(attr.fileToCreate);
            }
        }
    }
