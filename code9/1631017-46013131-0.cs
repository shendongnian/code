    public class MyOpenGenericAncestorMatchingStrategy : IGenericImplementationMatchingStrategy
    {
        public Type[] GetGenericArguments(ComponentModel model, CreationContext context)
        {
            return new[] { context.GenericArguments[1] };
        }
    }
    
    container.Register(Component.For(typeof(MyOpenGenericAncestor<,>))
    .ImplementedBy(typeof(MyPartiallyClosedDescendant<>), new MyOpenGenericAncestorMatchingStrategy()));
