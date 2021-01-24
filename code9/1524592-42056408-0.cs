            Stream respStream = null;
            try
            {
                respStream = webResponse.GetResponseStream();
                using(var tStreamReader = new StreamReader(respStream))
                {
        // If this line is reached you don't need to call Dispose manually on respStream
        // so you set it to null
        
                   respStream = null; 
                   try
                   {
                     //My Code
                   }
                   catch(Exception ex)
                   {
                    //My Code
                   }
                }
            }
            finally
            {
    // if respStream is not null then the using block did not dispose it
    // so it needs to be done manually:
               if(null != respStream)
                   respStream.Dispose();
            }
