    static void Main(string[] args)
            {
                var smb = new SmbFileContainer();
    
                if (smb.IsValidConnection())
                {
                    smb.CreateFile("testFile.txt", "Hello World");
                }
    
            }
