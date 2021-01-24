    public class Class1
    {
        public Class1() 
        {
            this.Courses = new HashSet<Course>();
        }
    
        public int Class1Id { get; set; }
    
        public virtual ICollection<Class2> Class2s { get; set; }
    }
            
    public class Class2
    {
        public Class1()
        {
            this.Class1s = new HashSet<Class1>();
        }
    
        public int Class2Id { get; set; }
    
        public virtual ICollection<Class1> Class1s { get; set; }
    }
