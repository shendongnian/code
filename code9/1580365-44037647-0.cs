    try
    {
        using (var ss = new extest()) {
            try
            {
                throw new Exception("Exception1");
            }
            catch (Exception exInner)
            {
                System.Console.WriteLine(ex.Message);
                throw;
            }
        }
    }   
    catch(Exception ex)
    {
        System.Console.WriteLine(ex.Message);
    }
