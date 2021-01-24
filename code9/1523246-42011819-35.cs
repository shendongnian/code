		var entityAssociations = typeof(Customer)
								.GetInterfaces()
								.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IHasAssociation<>))
								.Select(i => i.GetProperty("Association").GetValue(customer));
		
		
		foreach(var entityAssociation in entityAssociations)
		{
			Console.WriteLine($"{entityAssociation.GetType().FullName}");
		}
