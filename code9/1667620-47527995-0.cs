    public class employee
    {
        public int id {get; set;}
        public string name {get; set;}
        public string fname {get; set;}
        public virtual ICollection<language> language { get; set; }
    }
    public class language
    {
        public int id {get; set;}
        public string languageName {get; set;}
        public virtual ICollection<employee> employee { get; set; }
    }
