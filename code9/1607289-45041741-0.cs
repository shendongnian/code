    try 
    {
       operation1();
    }
    catch (Exception e)
    {
       try
       {
         operation2();
       }
       catch (Exception e2)
       {
          // etc
       }
    }
