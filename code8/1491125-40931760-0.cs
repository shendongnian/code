    public abstract class Parent { }
    public class Child : Parent
    {
        public Task SayAsync(string arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }
    }
    public delegate Task Invoker(Parent instance, string arg);
    class Program
    {
        static void Main(string[] args)
        {
            Parent instance = new Child(); // This will be obtained by calling a Func<Parent>
            var methodWithArg = instance.GetType().GetMethod("SayAsync");
            var func = GetDelegateWithArg(methodWithArg);
            func(instance, "Foo");
        }
        private static Invoker GetDelegateWithArg(MethodInfo method)
        {
            var instanceParameter = Expression.Parameter(typeof(Parent));
            var argParameter = Expression.Parameter(typeof(string));
            var body = Expression.Call(
                Expression.Convert(instanceParameter, method.DeclaringType),
                method,
                argParameter);
            var lambda = Expression.Lambda<Invoker>(body, instanceParameter, argParameter);
            return lambda.Compile();
        }
    }
