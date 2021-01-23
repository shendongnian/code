    public class Proposal
    {
    	[Key]
    	public int ProposalId { get; set; }
    
    	[Required, Column(TypeName = "text")]
    	public string Substantiation { get; set; }
    
    	public DateTime DateCreated { get; set; }
    }
    
    public class ProposalCustom : Proposal
    {
    	[Required, StringLength(255)]
    	public string Name { get; set; }
    
    	public int ProposalTypeId { get; set; }
    
    	[ForeignKey("ProposalTypeId")]
    	public virtual ProposalCustomType ProposalType { get; set; }
    }
    
    public class ProposalCustomType
    {
    	[Key]
    	public int ProposalTypeId { get; set; }
    
    	[Required, StringLength(255)]
    	public string Name { get; set; }
    
    	[Required, Column(TypeName = "text")]
    	public string Description { get; set; }
    
    	public ICollection<ProposalCustom> ProposalCustoms { get; set; }
    }
    
    public class ProposalLeave : Proposal
    {
    	public DateTime LeaveStart { get; set; }
    
    	public DateTime LeaveEnd { get; set; }
    
    	public int ProposalLeaveTypeId { get; set; }
    
    	[ForeignKey("ProposalLeaveTypeId")]
    	public virtual ProposalLeaveType LeaveType { get; set; }
    }
    
    public class ProposalLeaveType
    {
    	[Key]
    	public int LeaveTypeId { get; set; }
    
    	[Required, StringLength(255)]
    	public string Name { get; set; }
    
    	[Required, Column(TypeName = "text")]
    	public string Description { get; set; }
    
    	public ICollection<ProposalLeave> ProposalLeaves { get; set; }
    }
