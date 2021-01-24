    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<AppProfile>(); });
            this.Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfiguration)).InSingletonScope();
            this.Bind<Root>().ToSelf().InSingletonScope();
        }
    }
    public class Root
    {
        public Root(IMapper mapper)
        {
        }
    }
   ...
    var kernel = new StandardKernel(new AutoMapperModule());
    var root = kernel.Get<Root>();
