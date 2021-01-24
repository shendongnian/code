    static void Main(string[] args)
            {
                var data = Enumerable.Range(0, 10000).Select(i => new SyncContact { FirstName = "Test", LastName = "Person", Phone = "123-123-1234", Email = "test@test.com" }).ToArray();
    
                Stopwatch sw = new Stopwatch();
                long m1Time = 0;
                var total1 = 0;
                sw.Start();
                foreach (var item in data)
                {
                    var a = ToSyncDictionary(item);
                    total1++;
                }
                sw.Stop();
                m1Time = sw.ElapsedMilliseconds;
                sw.Reset();
                long m2Time = 0;
                var total2 = 0;
                sw.Start();
                foreach (var item in data)
                {
                    var a = ToSyncDictionary2(item);
                    total2++;
                }
                sw.Stop();
                m2Time = sw.ElapsedMilliseconds;
    
                Console.WriteLine($"ToSyncDictionary : {m1Time} for {total1}");
                Console.WriteLine($"ToSyncDictionary2 : {m2Time} for {total2}");
                Console.ReadLine();
            }
    
            public static IDictionary<string, string> ToSyncDictionary<T>(T value)
            {
                var syncProperties = from p in typeof(T).GetProperties()
                                     let name = p.GetCustomAttribute<SyncProperty>()?.PropertyName
                                     where name != null
                                     select new
                                     {
                                         Name = name,
                                         Value = p.GetValue(value)?.ToString()
                                     };
    
                return syncProperties.ToDictionary(p => p.Name, p => p.Value);
            }
    
            public static IDictionary<string, string> ToSyncDictionary2<T>(T value)
            {
                return Mapper<T>.ToSyncDictionary(value);
            }
    
            public static class Mapper<T>
            {
                private static readonly Func<T, IDictionary<string, string>> map;
    
                static Mapper()
                {
                    map = ObjectSerializer();
                }
    
                public static IDictionary<string, string> ToSyncDictionary(T value)
                {
                    return map(value);
                }
    
                private static Func<T, IDictionary<string, string>> ObjectSerializer()
                {
                    var type = typeof(Dictionary<string, string>);
                    var param = Expression.Parameter(typeof(T));
                    var newExp = Expression.New(type);
    
                    var addMethod = type.GetMethod(nameof(Dictionary<string, string>.Add), new Type[] { typeof(string), typeof(string) });
                    var toString = typeof(T).GetMethod(nameof(object.ToString));
    
                    var setData = from p in typeof(T).GetProperties()
                                  let name = p.GetCustomAttribute<SyncProperty>()?.PropertyName
                                  where name != null
                                  select Expression.ElementInit(addMethod,
                                                                Expression.Constant(name),
                                                                Expression.Condition(Expression.Equal(Expression.Property(param, p), Expression.Constant(null)),
                                                                           Expression.Call(Expression.Property(param, p), toString),
                                                                           Expression.Constant(null,typeof(string))));
    
                    return Expression.Lambda<Func<T, IDictionary<string, string>>>(Expression.ListInit(newExp, setData), param).Compile();
                }
            }
