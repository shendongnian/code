        public static void Main(string[] args)
        {
            IList<IEventHandler<IEvent>> handlers = new List<IEventHandler<IEvent>>();
            handlers.Add(new SomeEvent1Handler()); //Magicly works
            IEventHandler<IEvent> handler = handlers[0];
            handler.Handle(new SomeEvent2());
        }
