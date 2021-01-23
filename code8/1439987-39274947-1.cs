    public class Person : IPerson
    {
        [Dependency]
        public IAgeCalculator AgeCalculator { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Age => AgeCalculator.GetAge(this);
    }
