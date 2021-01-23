    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
    
        [NotMapped]
        public SelectList CitySelectList { get; set; }
    }
