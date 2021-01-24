     public class MyInterceptor : IInterceptor
     {
         public void Intercept(IInvocation invocation)
         {
             // The intercepted method
             var method = invocation.Request.Method;
             // the method of the concrete type which is intercepted
             var actualMethod = invocation.Request.Target.GetType()
                 .GetMethod(method.Name, method.GetParameters().Select(p => p.ParameterType).ToArray());
             // the desired attribute
             var myAttribute = actualMethod.GetCustomAttributes<MyAttribute>().FirstOrDefault();
             if (myAttribute == null)
            {
                invocation.Proceed();
            }
            else
            {
              // Do stuff
            }
         }
