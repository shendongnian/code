    public class Car
    {
        public void Drive(IWritable writable)
        {
            writable.Write("I'm driving!");
        }
    }
    new Car().Drive(new ConsoleWriter());
