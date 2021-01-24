     [XmlRoot("user_list")]
        public class UserList
        {
            public UserList() { }
            [XmlAttribute("user")]
            public List<User> Items { get; set; }
        }
        [XmlType("user")]
        public class User
        {
            // [XmlAttribute("id")]
            public string id { get; set; }
            // [XmlAttribute("name")]
            public string name { get; set; }
        }
