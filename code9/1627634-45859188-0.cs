    class WagonHandler : IHandleMessages
    {
        public void Handle(Wagon message)
        {
            Console.WriteLine($"Token {message.Token}");
            Console.WriteLine($"WagonId {message.WagonId}");
        }
    }
