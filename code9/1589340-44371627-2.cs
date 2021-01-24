    using System.ComponentModel.DataAnnotations;
    
    public class TestEntity
    {
        [Key]
        public int EntityID { get; set; }
        public string Name { get; set; }
    }
