    public class MyTestClass : ISomeInterface<string>
    {
        // Constructor
        public MyTestClass(IMyTestInterface implementationA,
                           IMyTestInterface implementationB,
                           IMyTestInterface implementationC)
        {
            // Some logic here     
        }
    
        public void MethodA(string)
        {    
        }
    }
