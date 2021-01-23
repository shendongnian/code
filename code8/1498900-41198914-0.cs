    public class Director
    {
       
    
    
        public int DirectorID { get; set; }
    
        public string fName { get; set; }
    
        public string lName { get; set; }
    
        public int Age { get; set; }
    
        public virtual ICollection<Film> Films{get;set;}
    
    }
