    public interface IWritable
    {
        void Write(string text);
    }
    public class ConsoleWriter : IWritable
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
