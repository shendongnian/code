    static void Main(string[] args)
    {
        string worker = "Small_Motivator";
            
        var factory = new EnumFactory();
        var enumValue = factory.GetByValue(worker);
    }
    public class EnumFactory
    {
        public object GetByValue(string sourceStr)
        {
            var enumTypes = new[]
            {
                typeof(Enums.Motivators),
                typeof(Enums.Movers),
                typeof(Enums.Reactors)
            };
            foreach (var type in enumTypes)
            {
                var enumValues = Enum.GetValues(type)
                    .Cast<object>()
                    .Select(x => x.ToString())
                    .ToArray();
                if (enumValues.Any(x => x == sourceStr))
                {
                    return Enum.Parse(type, sourceStr);
                }
            }
            throw new ArgumentException($"{sourceStr} not supported");
        }
    }
