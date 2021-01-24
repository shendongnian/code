    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Country_Id")]
        public virtual Country Country { get; set; }
        public int Country_Id { get; set; }
    }
    
