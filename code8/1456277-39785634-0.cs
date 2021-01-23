	public class Request
	{
		public int Id { get; set; }
		public string ClientNo { get; set; }
		
		public virtual ICollection<Master> MasterCollection { get; set; }
	}
	public class RequestMap  : EntityTypeConfiguration<Request>
	{
		HasKey(m => m.Id);
	}
	public class Master
	{
		// Id is same as RequestId
		public int Id { get; set; }
		public int RequestId { get; set; }
		public string SomeValue { get; set; }
		
		public virtual Request Request { get; set; }
		public virtual ICollection<Child> Childs { get; set; }
	}
	public class MasterConfig : EntityTypeConfiguration<Master>
	{
		public MasterConfig()
		{
			ToTable("Master", "MySchema");
			HasKey(k => k.Id);
			
			// Map Request and Master
			HasRequired(m => m.Request)
				.WithMany(m => m.MasterCollection)
				.HasForeignKey(m => m.RequestId);
		}
	}
	public class Child
	{
		public int Id { get; set; }
		public string SomeOtherValue { get; set; }
		public int MasterId { get; set; }
		
		public virtual Master Master { get; set; }
	}
	public class ChildConfig : EntityTypeConfiguration<Child>
	{
		public ChildConfig()
		{
			ToTable("Child", "MySchema");
			HasKey(k => k.Id);
			
			HasRequired(m => m.Master)
				.WithMany(m => m.Childs)
				.HasForeignKey(m => m.MasterId);
		}
	}
