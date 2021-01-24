    public static int Count<T>(Expression<Func<T, bool>> filter = null)
    {
        var ctx = new StackContext();
        return ctx.Customers.OfType<T>().Where(filter).Count();
    }
