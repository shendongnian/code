    public class Example
    {
        void DoSomething(int i)
        {
        }
        void DoSomething(float i)
        {
        }
    }
    public static class ExampleExtensions
    {
        public static void DoSomethingGeneric(this Example example, object objectParam)
        {
            var t = objectParam.GetType();
            var methods = typeof(example).GetMethods().Where(_ => _.Name == "DoSomething");
            var methodInfo = methods.Single(_ => _.GetParameters().First().ParameterType == t);
            methodInfo.Invoke(example, new[] { objectParam });
        }
    }
