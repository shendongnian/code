    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Country Country { get; set; }
        public int CountryId { get; set; }
    }
