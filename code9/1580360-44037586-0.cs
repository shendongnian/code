        class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var ss = new extest()) {
                    ...
                }
            }   
            catch(Exception ex)
            {
                System.Console.WriteLine("extest error : " + ex.Message);
            } 
        }
    
    
    }
    
    class extest : IDisposable
    {
        public void Dispose()
        {
            throw new Exception("Dispose failed: reason");
        }
    }
