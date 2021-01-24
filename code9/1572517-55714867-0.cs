      public class LoggingDependencyRegistrationModule : Autofac.Module
    {
        private readonly ILoggerFactory _lf;
        private readonly MethodInfo _mi;
        private readonly Type _t;
        public LoggingDependencyRegistrationModule(ILoggerFactory lf)
        {
            _lf = lf;
            _mi = typeof(LoggerFactoryExtensions).GetMethod(nameof(LoggerFactoryExtensions.CreateLogger), new[] { typeof(ILoggerFactory) });
            _t = typeof(ILogger);
        }
        private void OnComponentPreparing(object sender, PreparingEventArgs e)
        {
            var t = e.Component.Activator.LimitType;
            e.Parameters = e.Parameters.Union(new[]
            {
                new ResolvedParameter(
                    (p, i) =>
                                _t.IsAssignableFrom(p.ParameterType),
                   (p,i)=>{
                        if(p.ParameterType == _t)
                           return _lf.CreateLogger(t.ToString());
                        return  CreateLogger(_mi, p.ParameterType, _lf);
                       }
                   )
            });
        }
        private static object CreateLogger(MethodInfo mi, Type typeArg, ILoggerFactory loggerFactory)
        {
            Type genericArg = typeArg.GetGenericArguments().First();
            MethodInfo generic = mi.MakeGenericMethod(new[] { genericArg });
            return generic.Invoke(null, new[] { loggerFactory });
        }
     
        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            registration.Preparing += OnComponentPreparing;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_lf).SingleInstance();
            base.Load(builder);
        }
    }
