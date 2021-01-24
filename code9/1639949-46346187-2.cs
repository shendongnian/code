    public class OpenGenericAncestorMatchingStrategy : IGenericImplementationMatchingStrategy
    {
        public Type[] GetGenericArguments(ComponentModel model, CreationContext context)
        {
            return new[] { context.Handler.ComponentModel.Implementation };
        }
    }
