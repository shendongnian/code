    public class UserClaim
    {
        public string typ { get; set; }
        public string val { get; set; }
    }
    
    public class RootObject
    {
        public string id_token { get; set; }
        public string provider_name { get; set; }
        public List<UserClaim> user_claims { get; set; }
        public string user_id { get; set; }
    }
