    public class Client
    {
    	public int Id { get; set; }
    	public ICollection<GroupClient> Groups { get; set; }
    }
    
    public class Group
    {
    	public int Id { get; set; }
    	public ICollection<GroupClient> Clients { get; set; }
    }
    
    public class GroupClient
    {
    	public int Group_Id { get; set; }
    	public int Client_Id { get; set; }
    }
