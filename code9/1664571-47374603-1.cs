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
