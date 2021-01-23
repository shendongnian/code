    public class MultiTenantModelCacheKeyFactory : ModelCacheKeyFactory {
		private string _schemaName;
		public override object Create(DbContext context) {
			var dataContext = context as DomainDbContext;
			if(dataContext != null) {
				_schemaName = dataContext.SchemaName;
			}
			return new MultiTenantModelCacheKey(_schemaName, context);
		}
	}
