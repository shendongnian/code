    public class RVD
    {
        public int Id { get; set; }
        public Emp PrimaryDriver { get; set; }
        public Emp SecondaryDriver { get; set; }
    }
    
    public class Emp
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
