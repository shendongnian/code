    public class SystemAuthorizeAttribute : AuthorizeAttribute
    {
        public Form PermissionForm { get; set; } //Enum
        public PermissionValue Permissions { get; set; }//Enum
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var actionDescriptor = httpContext.Items["ActionDescriptor"] as ActionDescriptor;
            if (actionDescriptor != null)
            {
                var authorizeAttribute = this.GetSystemAuthorizeAttribute(actionDescriptor);
                // If the authorization attribute exists
                if (authorizeAttribute != null)
                {
                    // Run the authorization based on the attribute
                    var form = authorizeAttribute.PermissionForm;
                    var permissions = authorizeAttribute.Permissions;
                    // Return true if access is allowed, false if not...
                    if (!CurrentUserHasPermissionForm(form))
                    {
                        //Deny access code
                    }
                }
            }
            return true;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // Pass the current action descriptor to the AuthorizeCore
            // method on the same thread by using HttpContext.Items
            filterContext.HttpContext.Items["ActionDescriptor"] = filterContext.ActionDescriptor;
            base.OnAuthorization(filterContext);
        }
        private SystemAuthorizeAttribute GetSystemAuthorizeAttribute(ActionDescriptor actionDescriptor)
        {
            SystemAuthorizeAttribute result = null;
            // Check if the attribute exists on the action method
            result = (SystemAuthorizeAttribute)actionDescriptor
                .GetCustomAttributes(attributeType: typeof(SystemAuthorizeAttribute), inherit: true)
                .SingleOrDefault();
            if (result != null)
            {
                return result;
            }
            // Check if the attribute exists on the controller
            result = (SystemAuthorizeAttribute)actionDescriptor
                .ControllerDescriptor
                .GetCustomAttributes(attributeType: typeof(SystemAuthorizeAttribute), inherit: true)
                .SingleOrDefault();
            return result;
        }
    }
