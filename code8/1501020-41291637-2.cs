    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace AnalyzerTest
    {
        public static class Logger
        {
            public static void Log(params object[] parameters)
            {
                
            }
        }
    }
    namespace AnalyzerTest
    {
        public class Foo
        {
            public void Foo1(int a, int b)
            {
                // Didn't record any of the parameters
                Logger.Log();
                // Rest of method
            }
        }
    }
