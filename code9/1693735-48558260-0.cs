    public class ResourceConfigPool
    {
        public int ResourceId { get; set; }
        public string TabOrder { get; set; }
        public bool TabOrderBool 
        { 
            get { return TabOrder == "1"; } // or "Y"
        }
    }  
