		static public void OnReceiveData(ActionCode code, byte[] data)
		{
			var type = System.Reflection.Assembly.GetCallingAssembly()
				.GetTypes()
				.Where
				(
					t => t.GetCustomAttributes()
						  .OfType<ActionAttribute>()
						  .Where( a => a.ActionCode == code)
				          .Any()
				)
				.Single();
			
			var member = type
				.GetMethods(BindingFlags.Static | BindingFlags.Public)
				.Where
				( 
					m=> m.GetParameters()
						 .First()
				         .ParameterType == type
			 	)
				.Single();
			
			var instance = Activator.CreateInstance(type, new object[] { data });
			
			member.Invoke(null, new object[] { instance });
		} 
