    [Table("ContactInfo")] // SQLite attribute
    [DataContract(Name = "ContactInfo", Namespace = "")]
    public sealed class ContactInfo : DatabaseTableBase
    {
    	/// <summary>
    	/// Unique Id of the codebook.
    	/// </summary>
    	[PrimaryKey] // SQLite attribute
    	[AutoIncrement] // SQLite attribute
    	[Column("UniqueId")] // SQLite attribute
    	[IgnoreDataMember]
    	public override long UniqueId { get; set; }
    
    	[Column("ClaimId")] // SQLite attribute
    	[NotNull] // SQLite attribute
    	public long ClaimId { get; set; }
    
    	[Column("ContactType")] // SQLite attribute
    	[NotNull] // SQLite attribute
    	public ContactTypes ContactType { get; set; }
    
    	public ContactInfo()
    	{
    	}
    }
