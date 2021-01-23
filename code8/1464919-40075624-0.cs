    public class Entity1
    {
        public int Id { get; set; }
        public ICollection<Entity2> Collection2 { get; set; }
    }
    
    public class Entity2
    {
        public int Id { get; set; }
        public ICollection<Entity1> Collection1 { get; set; }
    }
