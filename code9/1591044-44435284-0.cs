    public class UserRequestResolver : DefaultContractResolver
        {
    
            private string propertyName;
    
            public UserRequestResolver()
            {
    
            }
            public UserRequestResolver(String name)
            {
    
                propertyName = name;
            }
             public new static readonly UserRequestResolver Instance = new UserRequestResolver();
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
             {
                 JsonProperty property = base.CreateProperty(member, memberSerialization);
                
                 if ( property.PropertyName == "requestList")
                {
                    property.PropertyName = propertyName;
                   
                }
    
                return property;
            }
        }
