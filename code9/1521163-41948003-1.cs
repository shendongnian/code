    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    internal sealed class MyAuthorizationAttribute : Attribute, IAuthorizationFilter, IOrderedFilter
    {
        public int Order => -2;
    }
