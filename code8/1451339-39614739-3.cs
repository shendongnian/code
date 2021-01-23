    class WriteToConsole : IBroadcastInterpreter
    {
        public void HandleBroadcast(byte[] input)
        {
            string text = Encoding.ASCII.GetString(input);
            Console.WriteLine(text);
        }
    }
