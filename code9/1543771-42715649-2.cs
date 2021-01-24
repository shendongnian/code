    public interface IJoeProvider 
    {
        List<Object> GetJoes(); 
    }
    public interface IJoeProvider<T> : IJoeProvider
    {
        List<T> GetJoes(); 
    }
 
    builder.RegisterGeneric(typeof(JoeProvider<>)
           .As(typeof(IJoeProvider<>)); 
    builder.RegisterGeneric(typeof(Param<>))
           .As(typeof(Param<>))
           .WithParameter(new ResolvedParameter(
               (pi, ctx) => pi.Name == "joes",
               (pi, ctx) => {
                   Type t = typeof(IJoeProvider<>).MakeGenericType(pi.ParameterType); 
                   IJoeProvider p = (IJoeProvider)ctx.Resolve(t); 
                   return p.GetJoes(); 
               }));
