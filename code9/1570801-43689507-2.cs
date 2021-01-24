    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Tags { get; set; }
    }
    class Pairing
    {
        public User User1 { get; set; }
        public User User2 { get; set; }
        public List<string> CommonTags { get; set; }
    }
