    public class Myclass
    {
        public int MyProperty { get; } = 123;
        public int MyProperty2 => 123;
        public Myclass()
        {
            MyProperty = 65; //This is Legal
            MyProperty2 = 104; // This is not
        }
    }
    
