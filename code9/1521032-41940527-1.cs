    public static class MessageFactory
    {
        public static Message<TKey, TValue> Create<TKey, TValue>(int ID, IDictionary<TKey, TValue> data) 
            => new Message<TKey, TValue>(ID, data);
        public class Message<TKey, TValue>
        {
            public Message(int ID, IDictionary<TKey, TValue> data) { ... }
        }
    }
