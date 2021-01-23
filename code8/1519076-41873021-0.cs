    public class Member
    {
        [JsonProperty("CREATED")]
        public List<Create> Created { get; set; }
        [JsonProperty("DATE")]
        public string Date { get; set; }
    }
    public class Create
    {
        [JsonProperty("isValidMemberPassword ")]
        public bool IsValidMemberPassword { get; set; }
        [JsonProperty("member_eid ")]
        public int MemberEid { get; set; }
    }
