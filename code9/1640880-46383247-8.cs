    public class Includes<T>
        {
            public Includes(Func<IQueryable<T>, IQueryable<T>> expression)
            {
                Expression = expression;
            }
    
            public Func<IQueryable<T>, IQueryable<T>> Expression { get; private set; }
        }
    
    
    public class Navigation
        {
            public string NavigationProperty { get; set; }
            public IList<string> InternalNavigationProperties { get; set; }
        }
