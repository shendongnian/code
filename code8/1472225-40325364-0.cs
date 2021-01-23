    public static class BaseBLBindingExtensions
    {
        public static IBindingInNamedWithOrOnSyntax<object> WhenEntityMatchesType<TEntityType>(
            this IBindingWhenSyntax<object> syntax)
        {
            return syntax.When(request => DoesEntityMatchType(request, typeof(TEntityType)));
        }
        private static bool DoesEntityMatchType(IRequest request, Type typeToMatch)
        {
            return typeToMatch.IsAssignableFrom(request.Service.GenericTypeArguments.Single());
        }
    }
