    private static void RegisterServices(IKernel kernel)
    {
        kernel.Bind<IMyContext>().To<MyContext>().InRequestScope();
        kernel.Bind<IErp>().To<Erp>().InRequestScope();
    }
