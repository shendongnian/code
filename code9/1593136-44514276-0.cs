	public class TenantedEntityQueryListener : IDocumentQueryListener
	{
		private readonly ICurrentTenantIdResolver _resolver;
		public TenantedEntityQueryListener(ICurrentTenantIdResolver resolver) : base(resolver) 
		{
			_resolver = resolver;
		}
	
		public void BeforeQueryExecuted(IDocumentQueryCustomization customization)
		{
			var type = customization.GetType();
			var entityType = type.GetInterfaces()
								 .SingleOrDefault(i => i.IsClosedTypeOf(typeof(IDocumentQuery<>))
													|| i.IsClosedTypeOf(typeof(IAsyncDocumentQuery<>)))
								 ?.GetGenericArguments()
								 .Single();
			if (entityType != null && entityType.IsAssignableTo<ITenantedEntity>())
			{
				// Add the "AND" to the the WHERE clause 
				// (the method has a check under the hood to prevent adding "AND" if the "WHERE" is empty)
				type.GetMethod("AndAlso").Invoke(customization, null);
				// Add "TenantId = 'Bla'" into the WHERE clause
				type.GetMethod( "WhereEquals", 
								new[] { typeof(string), typeof(object) }
							  )
					.Invoke(customization,
						new object[]
						{
							nameof(ITenantedEntity.TenantId),
							_resolver.GetCurrentTenantId()
						}
					);
			}
		}
	}
