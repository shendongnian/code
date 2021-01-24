    public class Movie
    {
        public int Id { get; set; }
    
        public string Title { get; set; }
    
        public virtual Person Director { get; set; }
    
        public virtual ICollection<Person> Actors { get; set; }
    }
   
     public class Person
        {
            public int Id { get; set; }
        
            public string Name { get; set; }
        
            public virtual ICollection<Movie> Movies_Actors { get; set; }
        
           public virtual ICollection<Movie> Movies_Directors { get; set; }
        }
