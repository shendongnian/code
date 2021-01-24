    public class MyComponentSelector : DefaultTypedFactoryComponentSelector
    {
        protected override string GetComponentName(MethodInfo method, object[] arguments)
        {
            return arguments[0].ToString();
        }
    }
