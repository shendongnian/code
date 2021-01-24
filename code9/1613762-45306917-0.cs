    public class ConfigTestDataProvider
    {
        public static IEnumerable<object[]> TestCases
        {
            get
            {
                yield return new object [] { (Func<Config, object>)((x) => x.Param1) };
                yield return new object [] { (Func<Config, object>)((x) => x.Param2) };
            }
        }
    }
