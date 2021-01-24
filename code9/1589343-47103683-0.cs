    public class TestEntity
    {
        [Key]
        public int EntityID { get; }//<-- missing set
        public string Name { get; set; }
    }
