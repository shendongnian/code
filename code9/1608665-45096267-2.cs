    public class SuppressExceptionBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces() => new Type[0];
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn result = getNext()(input, getNext);
            if (result.Exception != null)
            {
                result.Exception = null;
            }
            return result;
        }
        public bool WillExecute => true;
    }
