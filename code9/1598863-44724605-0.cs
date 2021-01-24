    public class NoDerivedContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            property.ShouldSerialize = _ => property.DeclaringType != typeof(DerivedClass);
            return property;
        }
    }
    // .................
    var obj = new DerivedClass { Field1 = "aaa", Field2 = "bbb" };
    var json = JsonConvert.SerializeObject(obj, new JsonSerializerSettings { 
        ContractResolver = new NoDerivedContractResolver() 
    });
    Console.WriteLine(json);
    // Output:
    //    {"Field1":"aaa"}
