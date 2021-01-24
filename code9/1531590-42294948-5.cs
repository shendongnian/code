    public class Actor
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }
        public List<UseCase> UseCases { get; set; } //keeping UseCases as reference - relation
        public Actor() { UseCases = new List<UseCase>(); }
    }
