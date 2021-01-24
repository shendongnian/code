    ublic class ExternalClass
    {
       public string EXproperty1 { get; set; }
       public string EXproperty2 { get; set; }
       public string EXproperty3 { get; set; }
    
       public ExternalClass() { }
    }
    
    public class NewClass:ExternalClass
    {            
        public string NewProperty1 { get; set; }
        public string NewProperty2 { get; set; }
        public NewClass() { }          
    }
