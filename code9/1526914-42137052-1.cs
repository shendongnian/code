    public class Tree
    {
        public int Id { get; set; }
        public string text { get; set; }
        public int ParentId { get; set; }
        public List<Tree> nodes { get; set; } // you cant mark a list as nullable type
    }
