    public class Person
    {
      public int PersonId { get; set; }
      public string Name { get; set; }        
      public virtual Car Car { get; set; }
    }
    
    public class Car
    {        
      public string LicensePlate { get; set; }
      public int PersonId { get; set; }
      public virtual Person Person { get; set; }
    }
    
    public class CarEntityTypeConfiguration : EntityTypeConfiguration<Car>
    {
      public CarEntityTypeConfiguration()
      {
         this.HasRequired(c => c.Person).WithOptional(p => p.Car);
         this.HasKey(c => c.PersonId);
      }
    }
