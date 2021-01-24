    string code =
    @"using System.Diagnostics;
         
    namespace MyNameSpace
    {
        public class MyClass
        {
            public int MyMethod()
            {
                Debugger.Break();
                var x = 3;
                var y = 4;
                return x * y;
            }
        }
    }";
