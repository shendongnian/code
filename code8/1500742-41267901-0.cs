    [Serializable]
    public class Contact {
        public String Name { get; set; }
        public String Number { get; set; }
        public Contact(String name, String number) {
           Name = name;
           Number = number;
        }
    }
