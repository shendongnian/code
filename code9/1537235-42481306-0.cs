    public class Client
    {
    	public int Id { get; set; }
    	[ForeignKey("Client_Id")]
    	public ICollection<GroupClient> Groups { get; set; }
    }
    
    public class Group
    {
    	public int Id { get; set; }
    	[ForeignKey("Group_Id")]
    	public ICollection<GroupClient> Clients { get; set; }
    }
