    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<AppProfile>(); });
            this.Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfiguration)).InSingletonScope();
        }
    }
   ...
    var kernel = new StandardKernel(new AutoMapperModule());
    var mapper = kernel.Get<IMapper>();
