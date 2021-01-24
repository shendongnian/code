    class WagonHandler : IHandleMessages<Wagon>
    {
        public async Task Handle(Wagon message)
        {
            Console.WriteLine($"Token {message.Token}");
            Console.WriteLine($"WagonId {message.WagonId}");
        }
    }
