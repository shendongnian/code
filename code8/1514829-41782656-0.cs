    class ABC
        {
            public int MyProperty { get; set; }
            public int MyProperty2 { get; set; }
        }
        static List<T> ConfigureMap<T>(Dictionary<int, T> input) where T : class
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap(input.GetType(), typeof(List<T>))
            .ConstructUsing(Construct));
            return Mapper.Map<List<T>>(input);
        }
        private static object Construct(object arg1, ResolutionContext arg2)
        {
            if (arg1 != null)
            {
                var val = arg1 as IDictionary;
                var argument = val.GetType().GetGenericArguments()[1];
                if (val != null)
                {
                    var type = Activator.CreateInstance(typeof(List<>).MakeGenericType(argument));
                    foreach (var key in val.Keys)
                    {
                        ((IList)type).Add(val[key]);
                    }
                    return type;
                }
            }
            return null;
        }
    var so = new Dictionary<int, ABC> { { 1, new ABC { MyProperty = 10, MyProperty2 = 30 } } };
    var dest = new List<ABC>();
    var res = ConfigureMap<ABC>(so);
