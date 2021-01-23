    public class ConsoleOutput : IOutput
    {
        public void Read()
        {
            Console.Read();
        }
        public string ReadLine()
        {
            return Console.ReadLine();
        }
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
