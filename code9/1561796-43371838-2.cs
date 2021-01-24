    public class CarEntityTypeConfiguration : EntityTypeConfiguration<Car>
    {
      public CarEntityTypeConfiguration()
      {
         this.HasRequired(c => c.Person).WithOptional(p => p.Car);                        
      }
    }    
