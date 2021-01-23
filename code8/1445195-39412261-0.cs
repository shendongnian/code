    class Program
        {
            static void Main(string[] args)
            {
                var obj1 = new
                {
                    Test = "a1",
                    SubObject = new
                    {
                        Id = 1
                    },
                    SubArray = new[] { new { Id = 1 }, new { Id = 2 } },
                    Value = 0
                };
    
                var my = new AnonymousSerializer(obj1);
                BinaryFormatter bf = new BinaryFormatter();
    
                byte[] data;
                using (MemoryStream ms = new MemoryStream())
                {
                    bf.Serialize(ms, my);
                    ms.Close();
                    data = ms.ToArray();
                }
    
                using (MemoryStream ms = new MemoryStream(data))
                {
                    var a = bf.Deserialize(ms) as AnonymousSerializer;
    
                    var obj2 = a.GetValue(obj1);
    
                    Console.WriteLine(obj1 == obj2);
                    
                }
                Console.ReadLine();
            }
    
            [Serializable]
            public class AnonymousSerializer : ISerializable
            {
                private object[] properties;
    
                public AnonymousSerializer(object objectToSerializer)
                {
                    Type type = objectToSerializer.GetType();
                    properties = type.GetProperties().Select(p =>
                    {
                        if (p.PropertyType.IsArray && IsAnonymousType(p.PropertyType.GetElementType()))
                        {
                            var value = p.GetValue(objectToSerializer) as IEnumerable;
                            return value.Cast<object>().Select(obj => new AnonymousSerializer(obj)).ToArray() ;
                        }else if (IsAnonymousType(p.PropertyType))
    	                {
                            var value = p.GetValue(objectToSerializer);
                            return new AnonymousSerializer(value);
                        }else{
                            return p.GetValue(objectToSerializer);
                        }
                    }).ToArray();
                }
    
                public AnonymousSerializer(SerializationInfo info, StreamingContext context)
                {
                    properties = info.GetValue("properties", typeof(object[])) as object[];
                }
    
    
                public void GetObjectData(SerializationInfo info, StreamingContext context)
                {
                    info.AddValue("properties", properties);
                }
    
                public T GetValue<T>(T prototype)
                {
                    return GetValue(typeof(T));
                }
    
                public dynamic GetValue(Type type)
                {
                    Expression<Func<object>> exp = Expression.Lambda<Func<object>>(Creator(type));
                    return exp.Compile()();
                }
    
                private Expression Creator(Type type)
                {
                    List<Expression> param = new List<Expression>();
    
                    for (int i = 0; i < type.GetConstructors().First().GetParameters().Length; i++)
                    {
                        var cParam = type.GetConstructors().First().GetParameters()[i];
                        if (cParam.ParameterType.IsArray && IsAnonymousType(cParam.ParameterType.GetElementType()))
                        {
                            var items = properties[i] as AnonymousSerializer[];
                            var itemType = cParam.ParameterType.GetElementType();
                            var data = items.Select(aser => aser.Creator(itemType)).ToArray();
                            param.Add(Expression.NewArrayInit(itemType, data));
                        }
                        else if (IsAnonymousType(cParam.ParameterType))
                        {
                            param.Add((properties[i] as AnonymousSerializer).Creator(cParam.ParameterType));
                        }
                        else
                        {
                            param.Add(Expression.Constant(properties[i]));
                        }
                    }
    
                    return Expression.New(type.GetConstructors().First(), param);
                }
    
                private static bool IsAnonymousType(Type type)
                {
                    bool hasCompilerGeneratedAttribute = type.GetCustomAttributes(typeof(CompilerGeneratedAttribute), false).Count() > 0;
                    bool nameContainsAnonymousType = type.FullName.Contains("AnonymousType");
                    bool isAnonymousType = hasCompilerGeneratedAttribute && nameContainsAnonymousType;
    
                    return isAnonymousType;
                }
            }
        }
    }
