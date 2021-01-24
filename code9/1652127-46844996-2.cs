    class MyCustomResolver : DefaultContractResolver
    {               
        public MyCustomResolver()
        {            
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            var attr = member.GetCustomAttribute(typeof(MyCustomJsonPropertyAttribute));
            if (attr!=null)
            {
                string jsonName = ((MyCustomJsonPropertyAttribute)attr).PropertyName;
                prop.PropertyName = jsonName;
            }
            return prop;
        }
        
    }
