    class Program
    {
        static void Main(string[] args)
        {
            ProxyGenerator generator = new ProxyGenerator();
            var person = new Person { Id = 1, Name = "Bob", Age = 40 };
            var proxy = generator.CreateClassProxyWithTarget<Person>(person, new EFInterceptor(new SecurityInfo()));
            Console.WriteLine("Id: {0}, Name: {1}, Age: {2}", person.Id, person.Name, person.Age);
            Console.WriteLine("Id: {0}, Name: {1}, Age: {2}", proxy.Id, proxy.Name, proxy.Age);
        }
    }
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
    }
    public interface ISecurityInfo
    {
        bool IsAllowed(string propName);
    }
    public class SecurityInfo : ISecurityInfo
    {
        public bool IsAllowed(string propName)
        {
            return propName != nameof(Person.Age);
        }
    }
    class EFInterceptor : Castle.DynamicProxy.IInterceptor
    {
        private readonly ISecurityInfo securityInfo;
        public EFInterceptor(ISecurityInfo info)
        {
            this.securityInfo = info;
        }
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.Name.StartsWith("get_"))
            {
                var propName = invocation.Method.Name.Replace("get_", "");
                HandleAccess(invocation, propName);
            }
            if (invocation.Method.Name.StartsWith("set_"))
            {
                var propName = invocation.Method.Name.Replace("set_", "");
                HandleAccess(invocation, propName);
            }
        }
        private void HandleAccess(IInvocation invocation, string propName)
        {
            if (!securityInfo.IsAllowed(propName))
            {
                invocation.ReturnValue = GetDefault(invocation.Method.ReturnType);
            } else
            {
                invocation.Proceed();
            }
        }
        public static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
    }
