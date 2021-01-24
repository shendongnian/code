    public static object[] GetEntityKey<T>(this DbContext context, T entity) where T : class
    {
        var state = context.Entry(entity);
        var metadata = state.Metadata;
        var key = metadata.FindPrimaryKey();
        var props = key.Properties.ToArray();
 
        return props.Select(x => x.GetGetter().GetClrValue(entity)).ToArray();
    }
