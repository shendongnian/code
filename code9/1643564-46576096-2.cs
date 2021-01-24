    /// <summary>
    /// The action parameter comes from the user's claims, if the user is authorized.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class FromClaimsAttribute : ModelBinderAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return parameter.BindWithModelBinding(new ClaimsPrincipalValueProviderFactory());
        }
    }
