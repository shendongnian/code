    public class NewClass: ExternalClass
    {
        public string NewProperty1 {get;set;}
        public string NewProperty2 {get;set;}
    
        public NewClass(){}
        public NewClass(ExternalClass externalClass){
            // you would have to copy all the properties
            this.EXproperty1 = externalClass.EXproperty1;
        }
    }
