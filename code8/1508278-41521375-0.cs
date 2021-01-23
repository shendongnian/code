    public class MemberRequest
    {
        public MemberRequest(){}
        public MemberRequest(string status)
        {
            this.status = status;
        }
        public MemberRequest(string email_address, string status)
        {
            this.status = status;
            this.email_address = email_address;
        }
        public string email_address { get; set; }
        public string status { get; set; }
    }
