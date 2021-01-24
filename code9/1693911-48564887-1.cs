    public class Emails
    {
        public int ID { get; set; }
        public string[] Addresses{ get;set; } 
        public Emails() {};
        public Emails(IEnumerable<string> list) 
        {
           this.Addresses = list.ToList().ToArray();
        }
