    static class ConnectionManager
    {
        public static SerialConnectionClass Connection { get; set; } = new SerialConnectionClass();
        public static EventHandler MessageReceived;
        public static void Send(string text)
        {
            Connection.Send(text);
        }
        ...
    }
