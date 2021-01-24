    class MainClass {
        public static void Main(string[] args) {
            var methodinfo = typeof(Test).GetMethod("TestMethod");
            var handle = methodinfo.MetaDataToken;
            MethodBase method = System.Reflection.MethodBase.GetMethodFromHandle(handle);
            string methodName = method.Name;
            string className = method.ReflectedType.Name;
    
            string fullMethodName = className + "." + methodName;
            Console.WriteLine(fullMethodName);
            Console.ReadLine();
        }
    }
    
    class Test {
        public static void TestMethod() {
            Console.WriteLine("Hello World!");
        }
    }
