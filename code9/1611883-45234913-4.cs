    public static class NinjectExtensions
    {
        public static IBindingInNamedWithOrOnSyntax<T> MakePreferredBinding<T>(
            this IBindingWhenSyntax<T> syntax)
        {
            return syntax.When(req => true);
        }
    }
