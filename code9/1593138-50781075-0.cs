    /// <summary>
	///     Interface for top-level entities, which belong to a tenant
	/// </summary>
	public interface ITenantedEntity
	{
		/// <summary>
		///     ID of a tenant
		/// </summary>
		string TenantId { get; set; }
	}
    /// <summary>
	///     Contact information [Tenanted document]
	/// </summary>
	public class Contact : ITenantedEntity
	{
		public string Id { get; set; }
		public string TenantId { get; set; }
		public string Name { get; set; }
	}
