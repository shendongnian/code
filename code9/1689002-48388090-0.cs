    public class Parts
    {
        public int Id {get; set; }
        public string Name {get; set; }
        public virtual ICollection<PartsSubParts> SubParts {get; set; }
    }
    
    public class SubParts
    {
        public int Id {get; set; }
        public string Name {get; set; }
    }
    public class PartsSubParts
    {
        public virtual Parts Part {get; set; }
        public virtual SubParts SubPart {get; set;}
        public int Order {get; set; }
    }
