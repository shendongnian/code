    public int InputCheck()
    {
        if (userInput >= 3) 
        {
             if (userInput <= 10)
             {
                 return userInput;
             }
             if (userInput > 10)
             {
                 return defaulInt = userInput;
             }
          }
         if (userInput < 3)
         {
            return defaultInt = userInput;
         }
    }
