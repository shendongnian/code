    internal class LoggingDependencyRegistrationModule : Autofac.Module
    {
        private static void OnComponentPreparing(object sender, PreparingEventArgs e)
        {
            e.Parameters = e.Parameters.Union(new[]
            {
                new ResolvedParameter(
                    (p, i) => p.ParameterType == typeof(ILogger),
                    (p, i) => LogService.GetLogger(p.Member.DeclaringType.FullName)),
            });
        }
        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            // Handle constructor parameters.
            registration.Preparing += OnComponentPreparing;
        }
    }
