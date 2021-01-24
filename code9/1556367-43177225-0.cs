    public class MyClass
    {
        int counter;
        public doSomethingExternal(A value) // A is base class
        {  
            counter++; 
            dynamic dynamicValue = value;
            doSomething(dynamicValue); // Correct overload will be used based on actual type
        }
        private doSomething(B b) {...}
        private doSomething(C c) {...}
        private doSomething(D d) {...}
    }
