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
                var item = new Item
                {
                    ItemLinks = links,
                };
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ItemLink, ItemLink>(); // you can extend this part of the configuration here
                    cfg.CreateMap<Item, Item>();
                    cfg.CreateMap<ItemLink, MyCustomClass>()
                        .ForMember(myCustomClass => myCustomClass.DescriptionWithDifferentName,
                            expression => expression.MapFrom(itemLink => itemLink.Description)); // to map to a different type
                    // more configs can do here
                    // e.g. cfg.CreateMap<Item, SomeOtherClass>();
                });
                IMapper mapper = new Mapper(config);
                ItemLink linkClone = mapper.Map<ItemLink>(links[0]);
                ItemLink[] linkArrayClone = mapper.Map<ItemLink[]>(item.ItemLinks);
                Item itemClone = mapper.Map<Item>(item);
                MyCustomClass myCustomClassObject = mapper.Map<MyCustomClass>(links[0]);
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
        public class MyCustomClass
        {
            public string DescriptionWithDifferentName { get; set; }
        }
    }
