    public class Property
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Guid PrimaryImageID { get; set; }
        public virtual PropertyImage PrimaryImage { get; set; }
        public ICollection<PropertyImage> Images { get; set; }
    }
