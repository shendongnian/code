    public class AccountInfo {
    	public int AccountId { get; set; }
    	public string UserName { get; set; }
    	public int TrinId { get; set; }
        public string LastName { get; set; }
    	public string FirstName { get; set; }
    	public Person PersonInfo { get; set; }
    	public List<Roles> AccountRoles { get; set; }
    }
