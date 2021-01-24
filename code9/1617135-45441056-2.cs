    public int MethodTest(int value)
    {
         try
         {
             return (0/value);
         } 
         catch(Exception ex)
         {
             return 1;
         }
    }
