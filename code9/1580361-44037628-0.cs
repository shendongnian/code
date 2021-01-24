    static void Main(string[] args)
    {
        try
        {
            using (var ss = new extest()) 
            {
               try
               {
                    CodeThatMightThrowAnException();
               }
               catch (Exception e)
               {
                   // Process Exception here
               }
            }
        }   
        catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        } 
    }
