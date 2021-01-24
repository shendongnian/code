    static void Main(string[] args)
    {
        File.Delete("TextTemplate1.txt"); //delete the existing file, to make sure the code does what its supposed to do
        Thread.Sleep(1000); //wait for filesystem to do its job
        var proc = new Process
        {
            StartInfo =
            {
                FileName = "TextTransform.exe",
                Arguments = "TextTemplate1.tt"
            }
        };
    
        proc.Start();
        proc.WaitForExit();
    }
