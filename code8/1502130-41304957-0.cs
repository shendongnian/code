    public class Test
    {
        public int X { get; private set; }
        public void SetX(int value)
        {
             //... your logic, throw exception if validation failed
             X = value;
        }
    }
