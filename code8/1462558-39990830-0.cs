    public static BronzeState GetInstance()
    {
         if (bronzeState != null)
              return bronzeState;
         else
         {
              bronzeState = new BronzeState();
              return bronzeState; 
         }
    }
