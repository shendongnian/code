        public static void Main()
        {
            var test = new List<YourDomainEntity>()
            {
                new YourDomainEntity() { Name = "1test", OtherProperty = "1"},
                new YourDomainEntity() { Name = "2test",  OtherProperty = "2" },
                new YourDomainEntity() { Name = "2test", OtherProperty = "1"   }
            };
            var k = Foo(test).ToList();
        }
        public interface INameOrderable
        {
            string Name { get; set; }
        }
        public interface IOtherPropertyOrderable
        {
            string OtherProperty { get; set; }
        }
        public static IEnumerable<T> Foo<T>(IEnumerable<T> list) where T : INameOrderable, IOtherPropertyOrderable
        {
            return list.OrderBy(a => a.Name, new NamesDescComparer()).ThenBy(b => b.OtherProperty);
        }
        public class NamesDescComparer : IComparer<string>
        {
            public int Compare(string x, string y) => -String.CompareOrdinal(x, y);
        }
        class YourDomainEntity : INameOrderable, IOtherPropertyOrderable
        {
            public string OtherProperty { get; set; }
            public string Name { get; set; }
        }
