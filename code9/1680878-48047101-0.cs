    public class NinjectBindings : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().ToMethod(ctx=> {
                return new BruceDbContext();
            });
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
