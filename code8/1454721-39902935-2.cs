    public class EntityContextFactory<TContext>
        where TContext: class, IDisposable, new()
    {
        private static TContext _dbContext;
        public static TContext Current()
        {
            TContext context = null;
            if (HttpContext.Current != null)
            {
                string objectContextKey = HttpContext.Current.GetHashCode().ToString("x") +
                                          typeof (TContext).GetHashCode().ToString(CultureInfo.InvariantCulture);
                if (HttpContext.Current.Items.Contains(objectContextKey) == false)
                {
                    context = new TContext();
                    HttpContext.Current.Items.Add(objectContextKey, context);
                }
                else
                {
                    context = HttpContext.Current.Items[objectContextKey] as TContext;
                }
            }
            else
            {
                    context = new TContext();
            }
            
            return context;
        }
    }
