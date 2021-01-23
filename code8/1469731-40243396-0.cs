    //Install-Package Castle.DynamicProxy
    
    public class Interceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.Out.WriteLine("Intercepting: " + invocation.Method.Name);
            invocation.Proceed();
        }
    }
    public class ABC
    {
        public virtual void MethodA()
        {
            Console.WriteLine("In method A");
        }
        public void MethodB()
        {
            Console.WriteLine("In method B");
        }
    }
