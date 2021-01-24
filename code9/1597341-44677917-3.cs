    public class DynamicMappingBuildStrategy: BuilderStrategy
	{
		public override void PreBuildUp(IBuilderContext context)
		{
			var policy = context.Policies.Get<IBuildKeyMappingPolicy>(context.BuildKey);
			if (policy != null)
			{
				context.BuildKey = policy.Map(context.BuildKey, context);
			}
			else
			{
				var oldMapping = context.BuildKey;
				var mappedType = DynamicMapper.GetMapping(oldMapping.Type);
				context.BuildKey = new NamedTypeBuildKey(mappedType, null);
				var lifetime = context.PersistentPolicies.Get<ILifetimePolicy>(oldMapping, true);
				if (lifetime != null)
				{
					context.PersistentPolicies.Set(lifetime, context.BuildKey);
				}
			}
		}
	}
