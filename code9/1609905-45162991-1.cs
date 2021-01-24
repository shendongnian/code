    namespace Plugin 
    {
        public class XEmployeeeControllerInterceptor : IInterceptor
        {
            public void Intercept(IInvocation invocation)
            {
                if(!invocation.Method.Name == nameof(Core.APi.EmployeeController.Get))
                {
                    return; 
                }
                invocation.Proceed(); 
                // alter return value 
                invocation.ReturnValue = invocation.ReturnValue + "-intercepted";
            }
        }
    }
