    Test t = new Test();
    t.MyValue = 1;
    t.MyValue = 1;
    public class Test
    {
        public Test()
        {
            
        }
        private int myValue;
        public int MyValue
        {
            get
            {
                return myValue;
            }
            set
            {
                myValue = value;
                Console.WriteLine($"Setter Called value->{myValue}");
            }
        }
    }
