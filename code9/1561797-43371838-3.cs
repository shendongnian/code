    public class PersonEntityTypeConfiguration : EntityTypeConfiguration<Person>
    {
      public PersonEntityTypeConfiguration()
      {
         this.HasOptional(p => p.Car).WithOptional(c => c.Person);                        
      }
    }    
