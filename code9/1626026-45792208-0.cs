    public class CustomAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            try
            {
                ServiceSecurityContext securityContext = operationContext.ServiceSecurityContext;
                WindowsIdentity callingIdentity = securityContext.WindowsIdentity;
    
                WindowsPrincipal principal = new WindowsPrincipal(callingIdentity);
                return principal.IsInRole("Administrators");
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
