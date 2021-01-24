    string input = "Bill@gmail.com";
    List<Peeps> tmp = JsonConvert.DeserializeObject<List<Peeps>>(json);
    //returns the base object
    var test = tmp.Where(a => a.emails.Any(b => b.email == input));
    //returns only the email object
    var testDuece = tmp.Where(a => a.emails.Any(b => b.email == input)).Select(c => c.emails.Where(a => a.email == input));
    
    public class Peeps
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<Emails> emails { get; set; }
    }
    public class Emails
    {
        public int id { get; set; }
        public string email { get; set; }
        public string dateCreated { get; set; }
    }
