    public class ClearAllPolicies : InjectionMember
    {
        public override void AddPolicies(Type serviceType, Type implementationType, string name, IPolicyList policies)
        {
            var serviceTypeBuildKey = new NamedTypeBuildKey(serviceType, name);
            policies.Clear<IBuildKeyMappingPolicy>(serviceTypeBuildKey);
            var buildKey = new NamedTypeBuildKey(implementationType, name);
            policies.Clear<IBuildKeyMappingPolicy>(buildKey);
            policies.Clear<IConstructorSelectorPolicy>(buildKey);
            policies.Clear<IBuildPlanCreatorPolicy>(buildKey);
            policies.Clear<IBuildPlanPolicy>(buildKey);
            policies.Clear<IMethodSelectorPolicy>(buildKey);
            policies.Clear<IPropertySelectorPolicy>(buildKey);
            policies.Clear<ILifetimeFactoryPolicy>(buildKey);
            policies.Clear<ILifetimePolicy>(buildKey);
            policies.Clear<IBuilderPolicy>(buildKey);
            DependencyResolverTrackerPolicy.RemoveResolvers(policies, buildKey);
        }
    }
