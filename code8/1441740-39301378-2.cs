    public interface IObjectCreationTracker
    {
        void Add(object obj);
        ICollection<object> CreatedObjects { get; }
    }
    public class ReferenceObjectCreationTracker : IObjectCreationTracker
    {
        public ReferenceObjectCreationTracker()
        {
            this.CreatedObjects = new HashSet<object>();
        }
        public void Add(object obj)
        {
            if (obj == null)
                return;
            var type = obj.GetType();
            if (type.IsValueType || type == typeof(string))
                return;
            CreatedObjects.Add(obj);
        }
        public ICollection<object> CreatedObjects { get; private set; }
    }
    public class ObjectCreationTrackerContractResolver : DefaultContractResolver
    {
        readonly SerializationCallback callback = (o, context) =>
            {
                var tracker = context.Context as IObjectCreationTracker;
                if (tracker != null)
                    tracker.Add(o);
            };
        protected override JsonContract CreateContract(Type objectType)
        {
            var contract = base.CreateContract(objectType);
            contract.OnDeserializedCallbacks.Add(callback);
            return contract;
        }
    }
