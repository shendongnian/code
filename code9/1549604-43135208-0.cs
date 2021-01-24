	internal class Program
	{
		static void Main( string[] args )
		{
			var container = new UnityContainer();
			container.RegisterType<IInterface, Implementation>();
                        // this will be created with this MyLogger instance
			var instance = container.Resolve<IInterface>( new TypedParameter( typeof(ILogger), new MyLogger() ) );
		}
	}
	internal class TypedParameter : ResolverOverride
	{
		private readonly Type _type;
		private readonly InjectionParameterValue _value;
		public TypedParameter( Type type, object value )
		{
			_type = type;
			_value = InjectionParameterValue.ToParameter( value );
		}
		public override IDependencyResolverPolicy GetResolver( IBuilderContext context, Type dependencyType )
		{
			ConstructorArgumentResolveOperation currentOperation = context.CurrentOperation as ConstructorArgumentResolveOperation;
			if ( currentOperation != null )
			{
				var parameter = currentOperation.TypeBeingConstructed.GetConstructors().Single().GetParameters().Single( x => x.Name == currentOperation.ParameterName );
				if (parameter.ParameterType == _type)
					return _value.GetResolverPolicy( dependencyType );
			}
				
			return null;
		}
	}
	// note that this is not registered with unity, is has to come from TypedParameter
	internal class MyLogger : ILogger
	{
	}
	internal interface ILogger
	{
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
