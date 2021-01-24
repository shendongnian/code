    public class FakeTestInterface : ITestInterface
    {
        public int NumberValue { get; private set; }
        public int number 
        {
            set
            {
                NumberValue = value;
            }
        }
    }
