    using AutoMapper;
    namespace Experiments
    {
        class Program
        {
            static void Main(string[] args)
            {
                var links = new ItemLink[]
                {
                    new ItemLink {Description = "desc 1"},
                    new ItemLink {Description = "desc 2"},
                };
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ItemLink, ItemLink>(); // you can extend this part of the configuration here
                    // more configs can go here
                });
                IMapper mapper = new Mapper(config);
                var clone = mapper.Map<ItemLink>(links[0]);
                var arrayClone = mapper.Map<ItemLink[]>(links);
            }
        }
        public class Item
        {
            public ItemLink[] ItemLinks { get; set; }
        }
        public class ItemLink
        {
            public string Description { get; set; }
        }
    }
