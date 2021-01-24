    public sealed class SpriteSurrogate : ObjectLookupSurrogate<string, Sprite>
    {
        static Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();
        static Dictionary<Sprite, string> spriteNames = new Dictionary<Sprite, string>();
        public static void AddSprite(string name, Sprite sprite)
        {
            if (name == null || sprite == null)
                throw new ArgumentNullException();
            sprites.Add(name, sprite);
            spriteNames.Add(sprite, name);
        }
        public static IEnumerable<Sprite> Sprites
        {
            get
            {
                return sprites.Values;
            }
        }
        protected override string GetId(Sprite realObject)
        {
            if (realObject == null)
                return null;
            return spriteNames[realObject];
        }
        protected override Sprite GetRealObject(string id)
        {
            if (id == null)
                return null;
            return sprites[id];
        }
    }
    public abstract class ObjectLookupSurrogate<TId, TRealObject> : ISerializationSurrogate where TRealObject : class
    {
        class SurrogatePlaceholder
        {
        }
        public void Register(SurrogateSelector selector)
        {
            foreach (var type in Types)
                selector.AddSurrogate(type, new StreamingContext(StreamingContextStates.All), this);
        }
        IEnumerable<Type> Types
        {
            get
            {
                yield return typeof(TRealObject);
                yield return typeof(SurrogatePlaceholder);
            }
        }
        protected abstract TId GetId(TRealObject realObject);
        protected abstract TRealObject GetRealObject(TId id);
        #region ISerializationSurrogate Members
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var original = (TRealObject)obj;
            var id = GetId(original);
            info.AddValue("id", id);
            // use Info.SetType() to force the serializer to construct an object of type ObjectReferenceWrapper<TRealObject> during deserialization.
            info.SetType(typeof(SurrogatePlaceholder));
        }
        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            // Having constructed an object of type ObjectReferenceWrapper<TRealObject>, 
            // look up the real sprite using the id in the serialization stream.
            var id = (TId)info.GetValue("id", typeof(TId));
            return GetRealObject(id);
        }
        #endregion
    }
