     public class MyControllerFactory : DefaultControllerFactory
        {
            public JumisPermissionControllerFactory(IControllerActivator controllerActivator, IEnumerable<IControllerPropertyActivator> propertyActivators)
                : base(controllerActivator, propertyActivators)
            {
    
            }
    
            public override object CreateController(ControllerContext context)
            {
                var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
                    var isDefined = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                        .Any(a => a.GetType().Equals(typeof(PermissionFilterAttribute)));
                    if (!isDefined)
                    {
                        throw new NotImplementedException();
                    }
 
                return base.CreateController(context);
            }
        }
