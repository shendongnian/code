`
protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
/// other registrations ...
            containerRegistry.RegisterSingleton<IMapperProvider, MapperProvider>();
            containerRegistry.RegisterInstance(typeof(IMapper), GetMapper(containerRegistry));
 }
        /// <summary>
        /// This function required in order for injection into custom automapper resolvers
        /// </summary>
        private IMapper GetMapper(IContainerRegistry container)
        {
            var mp = container.GetContainer().Resolve<IMapperProvider>(new[] { container });
            return mp.GetMapper();
        }
`
The mapper provider looks like this:
`
public class MapperProvider : IMapperProvider
    {
        private readonly IContainerRegistry _container;
        public MapperProvider(IContainerRegistry container)
        {
            _container = container;
        }
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ConstructServicesUsing(t => _container.GetContainer().Resolve(t));
                // any custom profile statement such as
                cfg.AddProfile<MappingSourcesProfile>();
                // ....
            });
            return config.CreateMapper();
        }
    }
`
Now my custom resolvers works, for example:
    public class BarcodesResolver : IValueResolver<repo.Book, Book, List<Barcode>>
    {
        private readonly IMapper _mapper;
        public BarcodesResolver(IMapper mapper)
        {
            _mapper = mapper;
        }
        public List<Barcode> Resolve(repo.Book source, Book destination, List<Barcode> destMember, ResolutionContext context)
        {
            repo.BookAttributes groupedAttribs = JsonConvert.DeserializeObject<repo.BookAttributes>(source.BookAttributes);
            return _mapper.Map<List<repo.Barcode>, List<Barcode>>(groupedAttribs.Barcodes);
        }
    }
`
The hard parts to work out here were how to specify that the containerRegistry needed to be passed into the constructor of the MapperProvider. There may be a better way of doing this but at least this works.
Also arriving at the line `cfg.ConstructServicesUsing(t => _container.GetContainer().Resolve(t));` was quite obscure as there seem to be few examples out there.
