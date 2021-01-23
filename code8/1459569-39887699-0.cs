    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var client = new ComChatClient();
            while (true)
            {
                client.WriteLine(Console.ReadLine());
            }
        }
    }
