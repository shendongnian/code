    class ResponseStrategy
    {
        private readonly IEnumerable<IInputHandler> _responses;
        public ResponseStrategy(IEnumerable<IInputHandler> responses)
        {
            // TODO protect from null input, etc.
            _responses = responses;
        }
        public ?void? Respond(string input)
        {
            // TODO put error handling in place and expect input to match no handlers
            _responses
                .First(r => r.CanHandle(input))
                .Handle(input);
        }
    }
    interface IInputHandler
    {
        bool CanHandle(string input);
        ?void? Handle(string input);
    }
    class DoAInputHandler : IInputHandler
    {
        public bool CanHandle(string input)
        {
            return input.contains("command1");
        }
        public ?void? Handle(string input)
        {
            // DoA();
        }
    }
    class DoBInputHandler : IInputHandler
    {
        public bool CanHandle(string input)
        {
            return input.contains("command2");
        }
        public ?void? Handle(string input)
        {
            // DoB();
        }
    }
