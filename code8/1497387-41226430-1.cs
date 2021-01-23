    public class NinjectDependencyResolver()
    {
       var context=new DbContext("someparameter","connectionStrin");
       kernel.Bind<IMyManager>().To<MyManager>().WithConstructorArgument("_dbContext",context);
       kernel.Bind<IMyRepository >().To<MyRepository >().WithConstructorArgument("_dbContext",context);
    }
