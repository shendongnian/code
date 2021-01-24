    public class LogBehavior : IInterceptionBehavior
    {
        public bool WillExecute => true;
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Enumerable.Empty<Type>();
        }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Debug.WriteLine("# before: " + input.MethodBase.Name);
            var result = getNext()(input, getNext);
            Console.WriteLine($"# end:{input.MethodBase.Name}");
            return result;
        }
    }
