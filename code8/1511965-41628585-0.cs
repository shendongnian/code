    public class Name
    {
        public string first_lower { get; set; }
        public string first { get; set; }
    }
    public class CharacterList
    {
        public string displayname { get; set; }
        public Name name { get; set; }
        public int id { get; set; }
    }
    public class Character
    {
        public List<CharacterList> character_list { get; set; }
    }
