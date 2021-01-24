    [XmlType("executeCreatePaperClipTransaction")]
    public partial class CustomExecuteCreatePaperClipTransaction : executeCreatePaperClipTransaction
    {
        [XmlElement(ElementName = "CreatePaperClipTransaction", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public CustomCreatePaperClipTransactionType ObjCreatePaperClipTransaction { get; set; }        
    }    
