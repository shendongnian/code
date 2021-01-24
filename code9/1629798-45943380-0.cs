    [TestClass]
    public class AttributeFinder
    {
        [TestMethod]
        public void MyTestMethod()
        {
            // Do something
        }
        
        public static void FindAttributes()
        {
            var assembly = Assembly.GetAssembly(typeof(AttributeFinder));
            var types = assembly.GetTypes();
            foreach (var t in types)
            {
                var typeAttr = t.GetCustomAttribute(typeof(TestClassAttribute));
                if (typeAttr != null)
                {
                    // Your class has a TestClass attribute on it!
                }
                
                var methods = t.GetMethods();
                foreach (var m in methods)
                {
                    var methodAttr = m.GetCustomAttribute(typeof(TestMethodAttribute));
                    if (methodAttr != null) 
                    {
                        // This method has the TestMethod attribute!
                    }
                }
            }
        }
    }
