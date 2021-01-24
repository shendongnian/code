        using System.Collections.Generic;
    using System.Dynamic;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                dynamic result = GetResult();
                if (result.Status == "Success")
                {
                    foreach (var item in result.list)
                    {
    
                    }
                }
            }
    
            public static ExpandoObject DoSomething()
            {
    
                dynamic result = new ExpandoObject();
                result.list = new List<MyObject>();
                return result;
            }
    
            public static ExpandoObject GetResult()
            {
                return DoSomething();
            }
        }
    
        internal class MyObject
        {
        }
    }
