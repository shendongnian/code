    // assuming namespace Contosco
    public class GenericMethodDiscoverer : IXunitTestCaseDiscoverer
    {
        public GenericMethodDiscoverer(IMessageSink diagnosticMessageSink)
        {
            DiagnosticMessageSink = diagnosticMessageSink;
        }
        protected IMessageSink DiagnosticMessageSink { get; }
        public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions,
            ITestMethod testMethod, IAttributeInfo factAttribute)
        {
            var result = new List<IXunitTestCase>();
            var types = factAttribute.GetNamedArgument<Type[]>("Types");
            foreach (var type in types)
            {
                var typeInfo = new ReflectionTypeInfo(type);
                var genericMethodInfo = testMethod.Method.MakeGenericMethod(typeInfo);
                var genericTestMethod = new GenericTestMethod(testMethod.TestClass, genericMethodInfo, typeInfo);
                var display = discoveryOptions.MethodDisplayOrDefault();
                result.Add(
                    new XunitTestCase(DiagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(),
                        genericTestMethod));
            }
            return result;
        }
    }
