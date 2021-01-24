        public static void Main()
        {
            var test = new List<YourDomainEntity>()
            {
                new YourDomainEntity() { Name = "1test" },
                new YourDomainEntity() { Name = "2test" }
            };
            var k = Foo(test).ToList();
        }
        public interface INameOrderable
        {
            string Name { get; set; }
        }
        public static IEnumerable<T> Foo<T>(IEnumerable<T> list) where T : INameOrderable
        {
            return list.OrderByDescending(a => a.Name.FirstOrDefault());
        }
        class YourDomainEntity : INameOrderable
        {
            public string Name { get; set; }
        }
