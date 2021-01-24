	internal class Program
	{
		static void Main( string[] args )
		{
			var container = new UnityContainer();
			container.RegisterType<IInterface, Implementation>( new MyInjectionConstructor() );
			// this instance will get a logger constructed with loggedType == typeof( Implementation )
			var instance = container.Resolve<IInterface>();
		}
	}
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
	internal interface ILogger
	{
	}
	internal class Logger : ILogger
	{
		public Logger( Type loggedType )
		{
		}
	}
	internal interface IInterface
	{
	}
	internal class Implementation : IInterface
	{
		public Implementation( ILogger logger )
		{
		}
	}
