    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (property.GetType().GetTypeName() == "object")
            {
                property.ShouldSerialize =
                    instance =>
                    {
                        var value = instance.GetType().GetProperty(property.UnderlyingName).GetValue(instance, null);
                        if (value == null)
                        {
                            return false;
                        }
                        if (value.GetType().GetTypeName() == "object")
                        {
                            if (NodeHasValue(value))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (value.GetType().GetTypeName() == "collection")
                            {
                                ICollection enumerable = (ICollection)value;
                                if (enumerable.Count != 0)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            return true;
                        }
                        return false;
                    };
            }
            return property;
        }
        public bool NodeHasValue(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var value = property.GetValue(obj, null);
                if (value == null)
                {
                    return false;
                }
                if (value.GetType().GetTypeName() == "object")
                {
                    return NodeHasValue(value);
                }
                if (value.GetType().GetTypeName() == "collection")
                {
                    ICollection enumerable = (ICollection)value;
                    if (enumerable.Count != 0)
                    {
                        return true;
                    }
                }
                if (value.GetType().GetTypeName() == "array")
                {
                    IList enumerable = (IList)value;
                    if (enumerable.Count != 0)
                    {
                        return true;
                    }
                }
                if (value.GetType().GetTypeName() != "object" 
                    && value.GetType().GetTypeName() != "collection" 
                    && value.GetType().GetTypeName() != "array")
                {
                    if (value != null)
                    {
                        var attribute = property.GetCustomAttribute(typeof(DefaultValueAttribute)) as DefaultValueAttribute;
                        if (attribute.Value.ToString() != value.ToString())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
