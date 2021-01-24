    public class Parent
    {
        [Key]
        public int Id { get; set; }
        protected virtual List<Child> Children {get; set;}
    
        [Ignore]
        public Child FirstChild 
        { 
             get{ return Children[0]; }
             set{ Children[0] = value; } 
        }
    
        [Ignore]
        public Child SecondChild 
        { 
             get{ return Children[1]; }
             set{ Children[1] = value; } 
        }
    }
    
    public class Child
    {
        [Key, ForeignKey("Application")]
        public int ApplicationId { get; set; }
        [Key]
        public int ParentId { get; set; }
        [Key]
        public int Id { get; set; }
    
        public Parent Parent { get; set; }
    }
