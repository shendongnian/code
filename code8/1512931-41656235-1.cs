    public class FormInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            bool isFormOnLoad = invocation.InvocationTarget is Form && invocation.Method.Name.Equals("OnLoad");
            if(isFormOnLoad)
            {
                Console.WriteLine("Before OnLoad");
            }
            invocation.Proceed();
            if(isFormOnLoad)
            {
                Console.WriteLine("After OnLoad");
            }
        }
    }
