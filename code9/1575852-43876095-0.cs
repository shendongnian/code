    public class NextPossibleRole
    {
        public string NextPossibleRoleId { get; set; }
        public string NextPossibleRoleLongName { get; set; }
        public string NextPossibleCareerLevel { get; set; }
    }
    
    public class Response
    {
        public string RequestReceived { get; set; }
        public string ResponseSent { get; set; }
        public string AfterAuth { get; set; }
        public string AfterRepo { get; set; }
        public int StatusCd { get; set; }
        public string ErrorDesc { get; set; }
        public List<NextPossibleRole> NextPossibleRole { get; set; }
    }
