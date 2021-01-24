    public class Section
    {
        public string Name { get; set; }    
        public List<Variable> Variables { get; set; }
    }
    
    public class Variable
    {
        public string Name { get; set; }    
        public string Type { get; set; }    
        public bool IsStandard { get; set; }
    }
