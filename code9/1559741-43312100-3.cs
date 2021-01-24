    public class LinkedListNodeListConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(List<LinkedListNode<T>>).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var list = (existingValue as IList<LinkedListNode<T>> ?? (IList<LinkedListNode<T>>)serializer.ContractResolver.ResolveContract(objectType).DefaultCreator());
            var table = serializer.Deserialize<LinkedListNodeOrderTable<T>>(reader);
            foreach (var node in table.ToNodeList())
                list.Add(node);
            return list;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var list = (IList<LinkedListNode<T>>)value;
            var table = LinkedListNodeOrderTable<T>.FromList(list);
            serializer.Serialize(writer, table);
        }
    }
    class LinkedListNodeOrderTable<T>
    {
        public static LinkedListNodeOrderTable<T> FromList(IList<LinkedListNode<T>> nodeList)
        {
            if (nodeList == null)
                return null;
            try
            {
                var list = nodeList.Where(n => n != null).Select(n => n.List).Distinct().SingleOrDefault();
                var table = new LinkedListNodeOrderTable<T>(list);
                var dictionary = list == null ? null : list.EnumerateNodes().Select((n, i) => new KeyValuePair<LinkedListNode<T>, int>(n, i)).ToDictionary(p => p.Key, p => p.Value);
                table.Indices = nodeList.Select(n => (n == null ? -1 : dictionary[n])).ToList();
                return table;
            }
            catch (Exception ex)
            {
                throw new JsonSerializationException(string.Format("Failed to construct LinkedListNodeOrderTable<{0}>",  typeof(T)), ex);
            }
        }
        public LinkedListNodeOrderTable(LinkedList<T> List)
        {
            this.List = List;
        }
        public LinkedList<T> List { get; set; }
        public List<int> Indices { get; set; }
        public IEnumerable<LinkedListNode<T>> ToNodeList()
        {
            if (Indices == null || Indices.Count < 1)
                return Enumerable.Empty<LinkedListNode<T>>();
            var array = List == null ? null : List.EnumerateNodes().ToArray();
            return Indices.Select(i => (i == -1 ? null : array[i]));
        }
    }
    public static class LinkedListExtensions
    {
        public static IEnumerable<LinkedListNode<T>> EnumerateNodes<T>(this LinkedList<T> list)
        {
            if (list == null)
                yield break;
            for (var node = list.First; node != null; node = node.Next)
                yield return node;
        }
    }
