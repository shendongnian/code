    [ProtoContract]
    public class RootObject
    {
        public RootObject()
        {
            this.People = new ObservableCollection<Person>();
        }
        [ProtoMember(1)]
        public ObservableCollection<Person> People { get; private set; }
        public event EventHandler<EventArgs<StreamingContext>> OnDeserialized;
        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            var onDeserialized = OnDeserialized;
            if (onDeserialized != null)
                onDeserialized(this, new EventArgs<StreamingContext> { Value = context });
        }
    }
    public class EventArgs<T> : EventArgs
    {
        public T Value { get; set; }
    }
