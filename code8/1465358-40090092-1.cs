    private static readonly IDictionary<int,Action<MyMessageType>> messageBehavior =
        new Dictionary<int,Action> {
            {153, (m) => { Console.WriteLine("Special action; message {0}", m); } },
            {154, (m) => { Console.WriteLine("Another special action ({0})", m); } }
        };
    ...
    Action<MyMessageType> special;
    if (messageBehavior.TryGetValue(message.id, out special)) {
        special(message);
    }
