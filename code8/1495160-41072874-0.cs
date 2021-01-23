    public class elementMap 
    {
        private ElementStruct p;
        public  ElementStruct P
        {
            set
            {
                p.ID = "id";
                p.Name = "name";
            }
            get {
                return p;
            }
        }
        private  ElementVal e;
        public  ElementVal E { set {
            e.ID = "id";
            e.Name = "name";
        }
            get {
                return e;
            }
        }
    }
    public class ElementStruct
    {
       public string ID { get; set; }
       public string Name { get; set; }
    }
    public class ElementVal
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
