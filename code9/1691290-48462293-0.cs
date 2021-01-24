    /// <summary>
    /// Define an attribute to define a parameter to be read from json content
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Parameter, Inherited = true, AllowMultiple = false)]
    public class FromJsonAttribute : ParameterBindingAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new JsonParameterBinding(parameter);
        }
    }
