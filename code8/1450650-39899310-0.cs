    public class CountryRetriever : IValueRetriever
    {
        public bool CanRetrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return propertyType.FullName.StartsWith("System.Collections.Generic.List`1[[SpecFlowExample.Country");
        }
        public object Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return keyValuePair.Value.Split(',')
                .Select(x => new Country {Name = x})
                .ToList();
        }
    }
    [Binding]
    public class Steps
    {
        [BeforeTestRun]
        public static void Setup()
        {
            TechTalk.SpecFlow.Assist.Service.Instance.RegisterValueRetriever(new CountryRetriever());
        }
        [When(@"i add some names")]
        public void WhenIAddSomeNames(Table table)
        {
            var things = table.CreateSet<FancyName>(() => new FancyName { Guid = Guid.NewGuid()});
        }
    }
