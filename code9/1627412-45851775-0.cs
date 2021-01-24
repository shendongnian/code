        class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(MapperConfiguration);
            var parent = new Parent()
            {
                Id = "a",
                Child = new Child()
                {
                    Name = "ChildA",
                    Id = 1
                }
            };
            var child = Mapper.Map<Child>(parent);
            Console.Read();
        }
        private static void MapperConfiguration(IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<Parent, Child>()
                .ProjectUsing(x => x.Child);
        }
        public class Parent
        {
            public string Id { get; set; }
            public Child Child { get; set; }
        }
        public class Child
        {
            public string Name { get; set; }
            public int Id { get; set; }
        }
    }
