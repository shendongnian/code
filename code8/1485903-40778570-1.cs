        public class MyBootstrapper : DefaultNancyBootstrapper
        {
            public override void Configure(INancyEnvironment environment)
            {
                environment.Json(retainCasing: true);
                base.Configure(environment);
            }
        }
