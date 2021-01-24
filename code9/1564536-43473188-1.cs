    public class Character {
        public string Name { get; set; }
        public string Surname { get; set; }
    
        public string FormatedName => $"{Name} {Surname}";
    }
