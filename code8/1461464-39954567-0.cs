     class Program
        {
            static void Main(string[] args)
            {
                for (int i = 0; i < 10000; i++)
                {
                    File.AppendAllText(@"c:\temp\1.txt", Guid.NewGuid().ToString());  
                }
                //read the file 
                using (FileStream fs = new FileStream(@"C:\temp\1.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                {
                    while (fs.CanRead)
                    {
                        //here I read a chunk of 1000 bytes to let stream open 
                        int len = 1000;
                        Thread.Sleep(1000);
                        byte[] array = new byte[len];
                        int bytesRead = fs.Read(array, 0, len);
                    }
                }
    
            }
        }
