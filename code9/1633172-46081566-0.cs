    public static class GenericCast
        {
            //This is the only way to create a real thread safe dictionary might not be required in you case you can make convertors during init of just not care for multi thread. The normal dictionary will work fine it might only call the compile a few times.
            public static ConcurrentDictionary<Type, Lazy<Func<IEnumerable<object>, object>>> creators = new ConcurrentDictionary<Type, Lazy<Func<IEnumerable<object>, object>>>();
    
            public static T CastAs<T>(this IEnumerable<object> data)
            {
                var dataType = typeof(T).GenericTypeArguments.First();
    
                var creator = creators.GetOrAdd(dataType, new Lazy<Func<IEnumerable<object>, object>>(() => {
                    var source = Expression.Parameter(
                        typeof(IEnumerable<object>));
    
                    var call = Expression.Call(
                        typeof(Enumerable), "Cast", new Type[] { dataType }, source);
    
                    var cast = Expression.Convert(call, typeof(object));
    
                    var exp = Expression.Lambda<Func<IEnumerable<object>, object>>(cast, source);
    
                    return exp.Compile();
                }));
    
                return (T)creator.Value(data);
            }
        }
