    public struct MyContainer
    {
        public int MyValue { get; }
        public MyContainer(int value)
        {
             MyValue = value; //readonly properties can be set in the constructor, similar to how readonly fields behave
        }
    }
