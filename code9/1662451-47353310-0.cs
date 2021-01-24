	container.RegisterType<IInterface, Implementation>( new MyInjectionConstructor() );
	internal class MyInjectionConstructor : InjectionMember
	{
		public override void AddPolicies( Type serviceType, Type implementationType, string name, IPolicyList policies )
		{
			policies.Set<IConstructorSelectorPolicy>( new MyConstructorSelectorPolicy(), new NamedTypeBuildKey( implementationType, name ) );
		}
	}
	internal class MyConstructorSelectorPolicy : DefaultUnityConstructorSelectorPolicy
	{
		protected override IDependencyResolverPolicy CreateResolver( ParameterInfo parameter )
		{
			if( parameter.ParameterType == typeof( ILogger ) )
			{
				return new LiteralValueDependencyResolverPolicy( new Logger( parameter.Member.DeclaringType ) );
			}
			return base.CreateResolver( parameter );
		}
	}
