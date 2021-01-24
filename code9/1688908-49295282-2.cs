    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Posting> Postings{ get; set; }
    }
