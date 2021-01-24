    namespace MyProject.Service // This is important 
    {
    	public partial class executeCreatePaperClipTransaction
    	{        
    		[XmlElement(ElementName = "CreatePaperClipTransaction", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
    		public CustomCreatePaperClipTransactionType ObjCreatePaperClipTransaction { get; set; }        
    	}   
    
    	public partial class CreatePaperClipTransactionType
    	{
    		[XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
    		public executeCreateLoanIncrease ObjLoanIncreaseRequest { get; set; }
    	}
    }
