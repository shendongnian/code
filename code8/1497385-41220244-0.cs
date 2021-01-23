    kernel.Bind<DbContext>().ToProvider<MyDbContextProvider>().InRequestScope();
    internal class MyDbContextProvider : Ninject.Activation.IProvider
    {
        public object Create(IContext context)
        {
            return new MyDbContext("connectionStringArgument";
        }
        public Type Type { get { return typeof (MyDbContext); } }
    }
