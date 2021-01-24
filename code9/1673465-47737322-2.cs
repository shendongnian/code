    public class Operation
    {
        public int Id { get; set; }
    
        public string Data { get; set; }
        [ForeignKey("Person")] // Add ForeignKey attribute
        public int PersonId { get; set; }
    
        public virtual Person Person{ get; set; }
    }
    public class Person
    {
        public Person()
        {
            Operations = new ICollection<Operation> ();
        }
        [Key] // Add key attribute
        public int Id { get; set; }
    
        public virtual ICollection<Operation> Operations { get; set; }
    }
