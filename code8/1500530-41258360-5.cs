     try
     {
         myDisposable.Do();
     }
     catch(Exception e)
     {
         Log("Error at something something",e); 
         throw e;
     }
     finally
     {
         myDisposable.Dispose(); 
     }
