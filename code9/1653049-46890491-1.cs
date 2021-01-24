    public class TargetClass
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Name => $"{FirstName} {Surname}";
    }
