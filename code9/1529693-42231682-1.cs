     interface ICust
     {
         public int CustID { get;}
     }
     class A : ICust
     {
         public int CustID { get; set; }
         public string Name{ get; set; }
     }
    
     class B : ICust
     {
         public int CustID { get; set; }
         public string Age { get; set; }
     }
    
     public void ProceesData(IList<ICust> param1, string date1)
     {
         Parallel.ForEach(param1, (currentItem) =>
         {
             GetDetails(currentItem.CustID)
         });
     }
