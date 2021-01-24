        public class UnityExtension<TInterface> : UnityContainerExtension
        {
            private readonly string _paramName;
            private readonly object _paramValue;
            public UnityExtension(string paramName, object paramValue)
            {
                _paramName = paramName;
                _paramValue = paramValue;
            }
            protected override void Initialize()
            {
                var strategy = new BuildStrategy<TInterface>(_paramName, _paramValue);
                Context.Strategies.Add(strategy, UnityBuildStage.PreCreation);
            }
        }
        public class BuildStrategy<TInterface> : BuilderStrategy
        {
            private readonly string _paramName;
            private readonly object _paramValue;
            public BuildStrategy(string paramName, object paramValue)
            {
                _paramName = paramName;
                _paramValue = paramValue;
            }
            public override void PreBuildUp(IBuilderContext context)
            {
                if (typeof(TInterface).IsAssignableFrom(context.OriginalBuildKey.Type))
                {
                    context.AddResolverOverrides(new ParameterOverride(_paramName, _paramValue));
                }
            }
        }
