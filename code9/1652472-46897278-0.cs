    public static class AutofacExtensions
    {
        public static IRegistrationBuilder<TService, SimpleActivatorData, SingleRegistrationStyle> RegisterModulePageViewModel<TService>(this ContainerBuilder builder) where TService : ServiceBase
        {
            return builder.Register(ctx => CreateInstance<TService>(ctx));
        }
    
        private static TService CreateInstance<TService>(IComponentContext ctx)
        {
            var ctor = typeof(TService).GetConstructors().Single();
            List<object> parameters = new List<object>();
            foreach (var param in ctor.GetParameters())
            {
                var keyAttribute = param.GetCustomAttribute<KeyFilterAttribute>();
                if (keyAttribute != null)
                {
                    parameters.Add(ctx.ResolveKeyed(keyAttribute.Key, param.ParameterType));
                }
                else
                {
                    parameters.Add(ctx.Resolve(param.ParameterType));
                }
            }
            return (TService)ctor.Invoke(parameters.ToArray());
        }
    }
