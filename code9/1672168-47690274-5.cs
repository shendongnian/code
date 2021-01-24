    public class CompanyFinal
    { 
        public int id { get; set; }
        public string name { get; set; }
        public bool Selected {get; set;}
        // for old user compatability:
        public string selected
        {
            get { return this.Selected ? "true" : "false"; }
        }
    }
