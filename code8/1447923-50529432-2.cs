    public class MultiTenantModelCacheKey : ModelCacheKey {
		private readonly string _schemaName;
		public MultiTenantModelCacheKey(string schemaName, DbContext context) : base(context) {
			_schemaName = schemaName;
		}
		public override int GetHashCode() {
			return _schemaName.GetHashCode();
		}
	}
