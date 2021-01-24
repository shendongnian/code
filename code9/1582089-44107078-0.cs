    private static readonly Dictionary<string, Func<ProductModel, int>> productModelGettersCache = new Dictionary<string, Func<ProductModel, int>>();
    public static Func<ProductModel, int> GetGetter(string column)
    {
        Func<ProductModel, int> getter;
        if (!productModelGettersCache.TryGetValue(column, out getter))
        {
            var par = Expression.Parameter(typeof(ProductModel));
            var exp = Expression.Lambda<Func<ProductModel, int>>(Expression.Property(par, column), par);
            getter = exp.Compile();
        }
        return getter;
    }
