    public class Film
    {
      
    
    
        public int FilmId { get; set; }
    
        public string Name { get; set; }
    
        public int Minutes { get; set; }
    
        public string AgeClassification { get; set; }
    
        public virtual Director Director { get; set; }
    }
