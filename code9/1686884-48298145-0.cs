    public interface IBusinessLogicFactory<TBusinessLogic>
    {
        TBusinessLogic Create(IOwinContext owinContext);
    }
    var factory = kernel.Bind<IBusinessLogicFactory<TBusinessLogic>>().ToFactory(() => new TypeMatchingArgumentInheritanceInstanceProvider());
    ...
    var businessLogic = kernel.Get<IBusinessLogicFactory<TBusinessLogic>>().Create(owinContext);
