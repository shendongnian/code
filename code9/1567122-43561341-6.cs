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
                Mapper.Initialize(cfg =>
                {
                    // now AutoMapper will try co create maps on it's own
                    cfg.CreateMissingTypeMaps = true; 
   
                    // we can still add custom maps like that
                    cfg.CreateMap<ItemLink, MyCustomClass>() 
                        .ForMember(myCustomClass => myCustomClass.DescriptionWithDifferentName,
                            expression => expression.MapFrom(itemLink => itemLink.Description));
                });
                ItemLink linkClone = Mapper.Map<ItemLink>(links[0]);
                ItemLink[] linkArrayClone = Mapper.Map<ItemLink[]>(item.ItemLinks);
                Item itemClone = Mapper.Map<Item>(item);
                // without custom map myCustomClassObject.DescriptionWithDifferentName would be null
                MyCustomClass myCustomClassObject = Mapper.Map<MyCustomClass>(links[0]);
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
    }
