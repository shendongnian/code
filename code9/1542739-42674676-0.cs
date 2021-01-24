    public class IPrincipalModelBinder: IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null) throw new ArgumentNullException("controllerContext");
            if (bindingContext == null) throw new ArgumentNullException("bindingContext");
            IPrincipal user = controllerContext.HttpContext.User;
            return user;
        }
    }
