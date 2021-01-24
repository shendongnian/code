     static void Main(string[] args)
            {
    
                Console.WriteLine("Test");
                Thread.Sleep(1000);
                try
                {
                    Test t = new Test();
                }
                catch (Exception ex)
                {
                           Console.WriteLine(ex.ToString());
                }
    class Test
        {
            static Test()
            {
                throw new Exception("Errror");
            }        
        }
