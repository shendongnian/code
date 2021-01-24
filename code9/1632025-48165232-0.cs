    public class LoggingDecorator<T> : DispatchProxy
    {
        private T _decorated;
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            try
            {
                LogBefore(targetMethod, args);
                var result = targetMethod.Invoke(_decorated, args);
                
                LogAfter(targetMethod, args, result);
                return result;
            }
            catch (Exception ex) when (ex is TargetInvocationException)
            {
                LogException(ex.InnerException ?? ex, targetMethod);
                throw ex.InnerException ?? ex;
            }
        }
        public static T Create(T decorated)
        {
            object proxy = Create<T, LoggingDecorator<T>>();
            ((LoggingDecorator<T>)proxy).SetParameters(decorated);
            return (T)proxy;
        }
        private void SetParameters(T decorated)
        {
            if (decorated == null)
            {
                throw new ArgumentNullException(nameof(decorated));
            }
            _decorated = decorated;
        }
        private void LogException(Exception exception, MethodInfo methodInfo = null)
        {
            Console.WriteLine($"Class {_decorated.GetType().FullName}, Method {methodInfo.Name} threw exception:\n{exception}");
        }
        private void LogAfter(MethodInfo methodInfo, object[] args, object result)
        {
            Console.WriteLine($"Class {_decorated.GetType().FullName}, Method {methodInfo.Name} executed, Output: {result}");
        }
        private void LogBefore(MethodInfo methodInfo, object[] args)
        {
            Console.WriteLine($"Class {_decorated.GetType().FullName}, Method {methodInfo.Name} is executing");
        }
    }
