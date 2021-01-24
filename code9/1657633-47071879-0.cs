    public static ClassData()
    {
       public static string GetData()
       {
           //Wish to mock TestResult method
           TestData TD=new TestData();
           string FinalResult=TD.TestResult();
           return GetData2(FinalResult);   
      }
      public static string GetData2(string FinalResult)
      {
           //Some logic
           return FinalResult;   
      }       
    }
