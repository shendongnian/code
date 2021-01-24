    public class ListMember
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
    }
    public class RootObject
    {
        public List<ListMember> listMember { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public int Year_of_issue { get; set; }
        public int Seats { get; set; }
        public int Carrying { get; set; }
        public string Maintenance { get; set; }
    }
