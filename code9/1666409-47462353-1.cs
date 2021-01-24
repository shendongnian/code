    public class TestClass
    {
        private readonly Dictionary<MethodType, Func<object[], IRequest>> _definitions;
        public TestClass(Dictionary<MethodType, Func<object[], IRequest>> definitions)
        {
            _definitions = definitions;
        }
        public IRequest MethodGenerator(MethodType methodType,
            params object[] args)
        {
            return _definitions[methodType](args);
        }
    }
