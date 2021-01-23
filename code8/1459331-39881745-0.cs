    public class Person
    {
        public Person()
        {
            Dependents = new List<Person>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Spouse { get; set; }
        public virtual ICollection<Person> Dependents { get; set; }
        public virtual Person Primary { get; set; }
    }
        
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {            
            HasRequired(t => t.Primary)
                .WithMany(t => t.Dependents)
                .HasForeignKey(d => d.Spouse);
    
        }
    }
