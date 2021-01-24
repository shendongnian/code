    using System.Diagnostics.CodeAnalysis;
    
    namespace MyNameSpace
    {
        public class MyClass
        {
            [SuppressMessage("ArbitraryCategoryNameSeemsToWork", "IDE0022")]
            public string MyMethod()
            {
                return MyPrivateMethod();
            }
    
            // This code raises a warning "Use expression body for methods".
            string MyPrivateMethod()
            {
                return "Hello";
            }
    
            // This code raises a warning "Use block body for methods".
            [SuppressMessage("ArbitraryCategoryNameSeemsToWork", "IDE0022")]
            public string MyMethod2() => MyPrivateMethod2();
    
            // This code raises a warning "Use block body for methods".
            string MyPrivateMethod2() => "Hello";
        }
    }
