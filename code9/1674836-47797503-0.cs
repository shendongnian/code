        static void Main(string[] args)
        {
            var fileName = ""; //put here test.dll path
            Assembly ass = Assembly.LoadFrom(fileName);
            var type = ass.GetType("Test.Test"); 
            var test = Activator.CreateInstance(type);
        }
