    public int RECORD_TYPE {get;set;} 
    pub string POS_TILL {get;set;} 
    Dim a List<TransactionSegment> Model   listTransactionSegment
    System.IO.StringReader stringReader = new System.IO.StringReader(Xml);  
    System.Xml.Serialization.XmlSerializer xmlSerializer = new 
    System.Xml.Serialization.XmlSerializer(typeof(List<TransactionSegment>));  
  
  
    //  
    listTransactionSegment=xmlSerializer.Deserialize(stringReader) as 
    List<TransactionSegment>;  
