    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
    public NinjectControllerFactory()
    {
        ninjectKernel = new StandardKernel();
        
    }
    protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
    {
        return controllerType == null
                   ? null
                   : (IController) ninjectKernel.Get(controllerType);
    }
   
    }
