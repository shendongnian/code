    public class InstanceClass
    {
        int field = 10;
        public void Method()
        {
            int field = 0;
            
            Console.WriteLine(field); //      outputs 0
            Console.WriteLine(this.field); // outputs 10 because "this" refers to field.
        }
    }
