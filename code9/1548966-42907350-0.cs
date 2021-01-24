    foreach (RecivedOrder o in RecivedDocument.Orders) 
    {
      if (!ReciveOrder.Check()) 
      {
         ... // Display order content on console
             // Then show errors:
         for (int i=0;i<Errors.Count;i++) Console.Writeline(Errors[i]) ;
      } 
    class RecivedOrder
     {
       // your properties
       internal List<String> Errors = null ;
    
       internal bool Check()
       {
         Errors = new List<String>() ;
         CheckAgreementId() ;
         CheckProductId() ;
         ... // other checks
         return Errors.Count==0 ;
       }
    
       internal void CheckAgreementId(out List<String> errors)
       {
         bool IdOk = AgreementId>=0 ;
         ... // more controls on AgreementId
         if (!IdOk) Errors.Add("Invalid AgreementId="+AgreementId) ;   
       }
    
        internal void CheckProductId(out List<String> errors)
       {
         ... 
