    public class MyDefaultContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var result = base.CreateProperties(type, memberSerialization).ToList();
            result.ForEach(x => { x.Ignored = false; }); // <-- Include or not? 
            return result;
        }
    }
