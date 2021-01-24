	public class TenantedEntityStoreListener : IDocumentStoreListener
	{
		private readonly ICurrentTenantIdResolver _resolver;
		public TenantedEntityStoreListener(ICurrentTenantIdResolver resolver) : base(resolver)
		{
			_resolver = resolver;
		}
		public bool BeforeStore(string key, object entityInstance, RavenJObject metadata, RavenJObject original)
		{
			var tenantedEntity = entityInstance as ITenantedEntity;
			if (tenantedEntity != null)
			{
				tenantedEntity.TenantId = _resolver.GetCurrentTenantId();
				return true;
			}
			return false;
		}
		public void AfterStore(string key, object entityInstance, RavenJObject metadata) {}
	}
