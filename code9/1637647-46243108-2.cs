    class F
    {
        public void F1()
        {
            Console.WriteLine("Hello F1");
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            var f = new F();
            
            foreach (var method in 
              // get the Type object, that will allow you to browse methods,
              // properties etc. It's the main entry point for reflection
              f.GetType()
                 // GetMethods allows you to get MethodInfo objects
                 // You may choose which methods do you want -
                 // private, public, static, etc. We use proper BindingFlags for that
                .GetMethods(
                  // this flags says, that we don't want methods from "object" type,
                  // only the ones that are declared here
                  BindingFlags.DeclaredOnly
                  // we want instance methods (use "Static" otherwise)
                | BindingFlags.Instance
                  // only public methods (add "NonPublic" to get also private methods)
                | BindingFlags.Public)
             
             // lastly, order them by name
             .OrderBy(x => x.Name))
            {
                //invoke the method on object "f", with no parameters (empty array)
                method.Invoke(f, new object[] { });
            }
        }
    }
