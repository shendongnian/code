    public class InstanceClass
    {
        int _field = 10;
        public void Method()
        {
            int field = 0;
            
            Console.WriteLine(field); 
            Console.WriteLine(_field); // prefixed with _.  
                                       // no conflicts
                                       // so "this" can be omitted.
        }
    }
