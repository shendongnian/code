    [AttributeUsage(AttributeTargets.Class)]
    public class TrackEnumValueActionAttribute : Attribute, ITestAction
    {
        public ActionTargets Targets
        {
            get
            {
                return ActionTargets.Test;
            }
        }
        public void AfterTest(ITest test)
        {
        }
        public void BeforeTest(ITest test)
        {
            if (!(test.Fixture is ICurrentExampleEnumValueHolder))
            {
                return;
            }
            var arguments = GetArgumentsFromTestMethodOrNull(test);
            if (arguments == null)
            {
                return;
            }
            var eumValue = GetEnumValueFromArgumentsOrNull<ExampleEnum>(arguments);
            (test.Fixture as ICurrentExampleEnumValueHolder).CurrentEnumValue = enumValue;
        }
        private object[] GetArgumentsFromTestMethodOrNull(ITest test)
        {
            return test
                .GetType()
                .GetProperty("Arguments", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.GetValue(test) as object[];
        }
        private T? GetEnumValueFromArgumentsOrNull<T>(object[] arguments) where T : struct
        {
            return arguments
                .Where(a => a.GetType().Equals(typeof(T)))
                .Select(a => (T?)a)
                .FirstOrDefault();
        }
    }
