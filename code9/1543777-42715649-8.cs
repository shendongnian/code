    public interface IParamProvider 
    {
        List<Object> GetParams(); 
    }
    public interface IParamProvider<T> : IParamProvider
    {
        List<T> GetParams(); 
    }
    public class ParamProvider<T> : IParamProvider<T>
    {
        public ParamProvider(String paramName)
        {
            this._paramName = paramName;
        }
        private readonly String _paramName;
        // Do IParamProviderProvider implementation
    }
    builder.RegisterGeneric(typeof(ParamProvider<>)
           .As(typeof(IParamProvider<>)); 
    builder.RegisterGeneric(typeof(Param<>))
           .As(typeof(Param<>))
           .WithParameter(new ResolvedParameter(
               (pi, ctx) => pi.ParameterType.IsGenericType 
                            && pi.ParameterType.GetGenericTypeDefinition() == typeof(List<>),
               (pi, ctx) => {
                   Type t = typeof(IParamProvider<>).MakeGenericType(pi.ParameterType); 
                   IParamProvider p = (IParamProvider)ctx.Resolve(t, new NamedParameter("paramName", pi.Name)); 
                   return p.GetParams(); 
               }));
