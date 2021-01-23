    public class Property
    {
        public int ID { get; set; }
        public string Name { get; set; }
    
        public ICollection<PropertyImage> Images { get; set; }
    }
    public class PropertyImage
    {
        [Key]
        public Guid ID { get; set; }
        public int PropertyID { get; set; }
        public bool IsPrimaryImage { get;set; }
    
        public virtual Property Property { get; set; }
    }
