    public class Car
    {
        private readonly IWritable _writer;
        public Car(IWritable writer)
        {
            _writer = writer;
        }
        public void Drive()
        {
            _writer.Write("I'm driving!");
        }
    }
