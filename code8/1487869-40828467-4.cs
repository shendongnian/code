     static void Main(string[] args)
     {
         bool userWantToEnd = false;
         showBegin();  
         while( !userWantToEnd)
         {
             decide();   
             userWantToEnd = IsUserWillingToContinue();
         }
         showEnd();
     }
