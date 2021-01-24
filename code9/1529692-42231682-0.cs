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
    
       public void ProceesData<T>(IList<T> param1, string date1) where T : ICust
        {
            Parallel.ForEach(param1, (currentItem) =>
            {
                GetDetails(currentItem.CustID)
            });
        }
