    [module: Interceptor]
    namespace GenericLogging
    {
    
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
        public class InterceptorAttribute : Attribute, IMethodDecorator
        {
            // instance, method and args can be captured here and stored in attribute instance fields
            // for future usage in OnEntry/OnExit/OnException
            public void Init(object instance, MethodBase method, object[] args)
            {
                Console.WriteLine(string.Format("Init: {0} [{1}]", method.DeclaringType.FullName + "." + method.Name, args.Length));
            }
    
            public void OnEntry()
            {
                Console.WriteLine("OnEntry");
            }
    
            public void OnExit()
            {
                Console.WriteLine("OnExit");
            }
    
            public void OnException(Exception exception)
            {
                Console.WriteLine(string.Format("OnException: {0}: {1}", exception.GetType(), exception.Message));
            }
        }
    
        public class Sample
        {
            [Interceptor]
            public void Method(int test)
            {
                Console.WriteLine("Your Code");
            }
        }
    }
    [TestMethod]
    public void TestMethod2()
    {
        Sample t = new Sample();
        t.Method(1);
    }
