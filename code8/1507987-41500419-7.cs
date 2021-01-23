    public class GetPlayerInfoResult
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class GetPlayerInfo
    {
        public List<GetPlayerInfoResult> GetPlayerInfoResult { get; set; }
    }
	
