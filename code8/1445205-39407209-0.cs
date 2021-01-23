    public class Phasessfilter
    {
        public string Searchterm {get;set;}
        public string ob1 {get;set;}
        public string ob2 {get;set;}
        public string ob3 {get;set;}
        public List<string> ob4 { get; set; }
        public List<string> ob5 { get; set; } 
        public Phasessfilter()
        {
            ob4 = new List<string>();
            ob5 = new List<string>();
        }
    }
