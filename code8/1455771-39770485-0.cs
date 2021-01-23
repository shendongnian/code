    void Main()
    {
    	var content = @"{""data"":{""UserID"":""MS100000041"",""RoleID"":5}}";
    	var Item = JsonConvert.DeserializeObject<UserDetails>(content);
    	Console.WriteLine(Item.data.UserID);
    	Console.WriteLine(Item.data.RoleID);
    }
    
    public class UserDetails
    {
    	public class Data
    	{
    		public string UserID { get; set; }
    		public int RoleID { get; set; }
    	}
    	public Data data { get; set; }
    }
