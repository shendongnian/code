    public class Property
    {
      public int ID { get; set; }
      public string Name { get; set; }
      public Guid PrimaryImageID { get; set; }
      [ForeignKey("PrimaryImageID")]
      public virtual PropertyImage PrimaryImage { get; set; }
      public ICollection<PropertyImage> Images { get; set; }
    }
    public class PropertyImage
    {
      [Key]
      public Guid ID { get; set; }
      public int PropertyID { get; set; }
    
      [ForeignKey("PropertyID")]
      public virtual Property Property { get; set; }
    }
