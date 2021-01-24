    ....
    // in ClassLibrary1 project
    using System;    
    namespace ClassLibrary1
    {
        public class Class1
        {
            public void Method()
            {
                throw new Exception("Unhandled exception");
            }
        }
    }    
    ....
    // in ConsoleApplication1 project
    // ClassLibrary1 must be referenced
    using System;    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                AppDomain currentDomain = AppDomain.CurrentDomain;
                currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyExceptionHandler);
    
                ClassLibrary1.Class1 class1 = new ClassLibrary1.Class1();
                class1.Method();
            }
    
            static void MyExceptionHandler(object sender, UnhandledExceptionEventArgs e)
            {// Break point here is hitting
                // ... Processing exception ...
            }
        }
    }
