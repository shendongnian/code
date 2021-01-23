    [ProtoContract]
    public class RedisDataObject
    {
        [ProtoMember(1)]
        public string DataHash;
        [ProtoIgnore]
        public Dictionary<ContextActions, List<Tuple<string, List<object>>>> Value;
        [ProtoMember(2)]
        private Dictionary<ContextActions, List<Tuple<string, List<DynamicTypeSurrogate<object>>>>> SurrogateValue
        {
            get
            {
                if (Value == null)
                    return null;
                var dictionary = Value.ToDictionary(
                    p => p.Key,
                    p => (p.Value == null ? null : p.Value.Select(i => Tuple.Create(i.Item1, i.Item2.ToSurrogateList())).ToList()));
                return dictionary;
            }
            set
            {
                if (value == null)
                    Value = null;
                else
                {
                    Value = value.ToDictionary(
                        p => p.Key,
                        p => (p.Value == null ? null : p.Value.Select(i => Tuple.Create(i.Item1, i.Item2.FromSurrogateList())).ToList()));
                }
            }
        }
    }
