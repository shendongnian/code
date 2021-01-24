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
            
            foreach (var method in f.GetType().GetMethods(
                  // this flags says, that we don't want methods from "object" type,
                  // only the ones that are declared here
                  BindingFlags.DeclaredOnly
                  // we want instance methods (use "Static" otherwise)
                | BindingFlags.Instance
                  // only public methods (add "NonPublic" to get also private methods)
                | BindingFlags.Public)
             .OrderBy(x => x.Name))
            {
                //invoke the method on object "f", with no parameters
                method.Invoke(f, new object[] { });
            }
        }
    }
