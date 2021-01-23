    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var client = new ComChatClient();
            Application.Run(new ChatWindow(client));
        }
    }
