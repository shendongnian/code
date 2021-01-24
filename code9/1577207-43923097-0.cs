    public class People : Collection<Person> {  }
    public class Person {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public IList<Email> emails { get; set; }
    }
    public class Email {
        public int id { get; set; }
        public string email { get; set; }
        public DateTime dateCreated { get; set; }
    }
