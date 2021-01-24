    class Program
    {
        static void Main(string[] args)
        {
            new TestClass().Foo(new TestData());
        }
    }
    public class TestClass
    {
        [ObservingAspect]
        [ArgumentChangingAspect]
        public int Foo(TestData data)
        {
            Console.WriteLine("Method observed: {0}", data.Property);
            return data.Property;
        }
    }
    public class TestData
    {
        public int Property { get; set; }
    }
    [AspectTypeDependency(AspectDependencyAction.Order, AspectDependencyPosition.Before, typeof(ObservingAspect))]
    [PSerializable]
    public class ArgumentChangingAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            ((TestData) args.Arguments[0]).Property = 42;
        }
    }
    [PSerializable]
    public class ObservingAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("Aspect observed: {0}", ((TestData)args.Arguments[0]).Property);
        }
    }
