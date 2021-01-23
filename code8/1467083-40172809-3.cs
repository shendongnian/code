    static void SimulateTyping<T>(T message, int delay = 100) {
        foreach (char character in message.ToString())
        {
            Console.Write(character);
            System.Threading.Thread.Sleep(delay);
        }
    }
