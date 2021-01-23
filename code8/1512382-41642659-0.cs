    public class Car
    {
      ...
      public virtual ICollection<CarImage> Images { get; set; } // <-- Adding this relation makes the problem go away :-)
 
      [ForeignKey("PrimaryImageID")]
      public virtual CarImage PrimaryImage { get; set; }
      public int? PrimaryImageID { get; set; }
    }
