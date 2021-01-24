    public class ConfigTestCase
    {
        public static readonly IReadOnlyDictionary<string, Func<Config, string>> testCases = new Dictionary<string, Func<Config, string>>
        {
            { nameof(Config.Param1), (Config x) => x.Param1 },
            { nameof(Config.Param2), (Config x) => x.Param2 }
        }
        .ToImmutableDictionary();
        public static IEnumerable<object[]> TestCases
        {
            get
            {
                var items = new List<object[]>();
                foreach (var item in testCases)
                    items.Add(new object[] { item.Key });
                return items;
            }
        }
    }
