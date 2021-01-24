    public class NewClass
    {
        public ExternalClass ExternalClass {get;set;}
        public string NewProperty1 {get;set;}
        public string NewProperty2 {get;set;}
    
        public string EXproperty1 {get { return this.ExternalClass.EXproperty1; };set{ this.ExternalClass.EXproperty1 = value; }; }
        public string EXproperty2 {get { return this.ExternalClass.EXproperty2; };set{ this.ExternalClass.EXproperty2 = value; }; }
        public string EXproperty3 {get { return this.ExternalClass.EXproperty3; };set{ this.ExternalClass.EXproperty3 = value; }; }
    
        public NewClass(){}
        public NewClass(ExternalClass externalClass){
            this.ExternalClass=externalClass;
        }
    }
