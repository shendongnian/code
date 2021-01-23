    class ChachaConverter : LinkedListItemConverter<Chacha>
    {
        protected override bool IsNextItemProperty(JsonProperty member)
        {
            return member.UnderlyingName == "NextChacha"; // Use nameof(Chacha.NextChacha) in latest c#
        }
    }
    public abstract class LinkedListItemConverter<T> : JsonConverter where T : class
    {
        const string refProperty = "$ref";
        const string idProperty = "$id";
        const string NextItemListProperty = "nextItemList";
        [ThreadStatic]
        static int level;
        // Increments the nesting level in a thread-safe manner.
        int Level { get { return level; } set { level = value; } }
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        protected abstract bool IsNextItemProperty(JsonProperty member);
        List<T> GetNextItemList(object value, JsonObjectContract contract)
        {
            var property = contract.Properties.Where(p => IsNextItemProperty(p)).Single();
            List<T> list = null;
            for (var item = (T)property.ValueProvider.GetValue(value); item != null; item = (T)property.ValueProvider.GetValue(item))
            {
                if (list == null)
                    list = new List<T>();
                list.Add(item);
            }
            return list;
        }
        void SetNextItemLinks(object value, List<T> list, JsonObjectContract contract)
        {
            var property = contract.Properties.Where(p => IsNextItemProperty(p)).Single();
            if (list == null || list.Count == 0)
                return;
            var previous = value;
            foreach (var next in list)
            {
                if (next == null)
                    continue;
                property.ValueProvider.SetValue(previous, next);
                previous = next;
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            using (new PushValue<int>(Level + 1, () => Level, (old) => Level = old))
            {
                writer.WriteStartObject();
                if (serializer.ReferenceResolver.IsReferenced(serializer, value))
                {
                    writer.WritePropertyName(refProperty);
                    writer.WriteValue(serializer.ReferenceResolver.GetReference(serializer, value));
                }
                else
                {
                    writer.WritePropertyName(idProperty);
                    writer.WriteValue(serializer.ReferenceResolver.GetReference(serializer, value));
                    var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(value.GetType());
                    // Write the data properties (if any).
                    foreach (var property in contract.Properties
                        .Where(p => p.Readable && !p.Ignored && (p.ShouldSerialize == null || p.ShouldSerialize(value))))
                    {
                        if (IsNextItemProperty(property))
                            continue;
                        var propertyValue = property.ValueProvider.GetValue(value);
                        if (propertyValue == null && serializer.NullValueHandling == NullValueHandling.Ignore)
                            continue;
                        writer.WritePropertyName(property.PropertyName);
                        serializer.Serialize(writer, propertyValue);
                    }
                    if (Level == 1)
                    {
                        // Write the NextItemList ONLY AT THE TOP LEVEL
                        var nextItems = GetNextItemList(value, contract);
                        if (nextItems != null)
                        {
                            writer.WritePropertyName(NextItemListProperty);
                            serializer.Serialize(writer, nextItems);
                        }
                    }
                }
                writer.WriteEndObject();
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var jObject = JObject.Load(reader);
            // Detach and process $ref
            var refValue = (string)jObject[refProperty].RemoveFromLowestPossibleParent();
            if (refValue != null)
            {
                var reference = serializer.ReferenceResolver.ResolveReference(serializer, refValue);
                if (reference != null)
                    return reference;
            }
            // Construct the value
            var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(existingValue == null ? typeof(T) : existingValue.GetType());
            T value = (existingValue as T ?? (T)contract.DefaultCreator());
            // Detach and process $id
            var idValue = (string)jObject[idProperty].RemoveFromLowestPossibleParent();
            if (idValue != null)
            {
                serializer.ReferenceResolver.AddReference(serializer, idValue, value);
            }
            // Detach the (possibly large) list of next items.
            var nextItemList = jObject[NextItemListProperty].RemoveFromLowestPossibleParent();
            // populate the data properties (if any)
            serializer.Populate(jObject.CreateReader(), value);
            // Set the next item references
            if (nextItemList != null)
            {
                var list = nextItemList.ToObject<List<T>>(serializer);
                SetNextItemLinks(value, list, contract);
            }
            return value;
        }
    }
    public struct PushValue<T> : IDisposable
    {
        Action<T> setValue;
        T oldValue;
        public PushValue(T value, Func<T> getValue, Action<T> setValue)
        {
            if (getValue == null || setValue == null)
                throw new ArgumentNullException();
            this.setValue = setValue;
            this.oldValue = getValue();
            setValue(value);
        }
        #region IDisposable Members
        // By using a disposable struct we avoid the overhead of allocating and freeing an instance of a finalizable class.
        public void Dispose()
        {
            if (setValue != null)
                setValue(oldValue);
        }
        #endregion
    }
    public static class JsonExtensions
    {
        public static JToken RemoveFromLowestPossibleParent(this JToken node)
        {
            if (node == null)
                return null;
            var contained = node.AncestorsAndSelf().Where(t => t.Parent is JContainer && t.Parent.Type != JTokenType.Property).FirstOrDefault();
            if (contained != null)
                contained.Remove();
            // Also detach the node from its immediate containing property -- Remove() does not do this even though it seems like it should
            if (node.Parent is JProperty)
                ((JProperty)node.Parent).Value = null;
            return node;
        }
    }
