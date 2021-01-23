     static void Main(string[] args)
     {
         bool userWantToEnd = false;
  
         while( !userWantToEnd)
         {
             showBegin();
             decide();   
             userWantToEnd = IsUserWillingToContinue();
         }
         showEnd();
     }
