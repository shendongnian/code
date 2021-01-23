    public class WindsorControllerFactory : DefaultControllerFactory
	{
		private readonly IKernel _kernel;
		public WindsorControllerFactory(IKernel kernel)
		{
			_kernel = kernel;
		}
		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			if (controllerType == null)
			{
				throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
			}
			if (_kernel.GetHandler(controllerType) != null)
			{
				return (IController)_kernel.Resolve(controllerType);
			}
			return base.GetControllerInstance(requestContext, controllerType);
		}
		public override void ReleaseController(IController controller)
		{
			_kernel.ReleaseComponent(controller);
		}
	}
