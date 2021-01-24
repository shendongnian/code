    public class Link
    {
        public int ID { get; set; }
        public string Name { get; set; }        
        public int ProjectID { get; set; }
        public virtual Project Project {get: set;}
    }
