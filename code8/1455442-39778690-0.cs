    public static class JsonSerializerExtensions
        {
            /// <summary>
            /// Convert entity to JSON without blowing up on cyclic reference.
            /// </summary>
            /// <param name="target">The object to serialize</param>
            /// <param name="entityTypes">Any entity-framework-related types that might be involved in this serialization.  If null, it will only use the type of "target".</param>
            /// <param name="ignoreNulls">Whether nulls should be serialized or not.</param>
            /// <returns>Json</returns>
            /// <remarks>This requires some explanation: all POCOs used by entites aren't their true form.  
            /// They're subclassed proxies of the object you *think* you're defining.  These add a new member
            /// _EntityWrapper, which contains cyclic references that break the javascript serializer.
            /// This is Json Serializer function that skips _EntityWrapper for any type in the entityTypes list.
            /// If you've a complicated result object that *contains* entities, forward-declare them with entityTypes.
            /// If you're just serializing one object, you can omit entityTypes.
            ///</remarks>
            public static string ToJsonString(this object target, IEnumerable<Type> entityTypes = null, bool ignoreNulls = true)
            {
                var javaScriptSerializer = new JavaScriptSerializer();
                if(entityTypes == null)
                {
                    entityTypes = new[] { target.GetType() };
                }
                javaScriptSerializer.RegisterConverters(new[] { new EntityProxyConverter(entityTypes, ignoreNulls) });
                return javaScriptSerializer.Serialize(target);
            }
        }
    
        public class EntityProxyConverter : JavaScriptConverter
        {
            IEnumerable<Type> _EntityTypes = null;
            bool _IgnoreNulls;
            public EntityProxyConverter(IEnumerable<Type> entityTypes, bool ignoreNulls = true) : base()
            {
                _EntityTypes = entityTypes;
                _IgnoreNulls = ignoreNulls;
            }
    
            public override IEnumerable<Type> SupportedTypes
            {
                get
                {
                    return _EntityTypes;
                }
            }
    
            public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
            {
                throw new NotImplementedException();
            }
    
            public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
            {
                var result = new Dictionary<string, object>();
                if (obj == null)
                {
                    return result;
                }
                var properties = obj.GetType().GetProperties(
                    System.Reflection.BindingFlags.Public 
                    | System.Reflection.BindingFlags.Instance 
                    | System.Reflection.BindingFlags.GetProperty
                );
                foreach (var propertyInfo in properties.Where(p => Attribute.GetCustomAttributes(p, typeof(ScriptIgnoreAttribute), true).Length == 0))
                {
                    if (!propertyInfo.Name.StartsWith("_"))
                    {
                        var value = propertyInfo.GetValue(obj, null);
                        if (value != null || !_IgnoreNulls)
                        {
                            result.Add(propertyInfo.Name, propertyInfo.GetValue(obj, null));
                        }
                    }
                }
                return result;
            }
        }
