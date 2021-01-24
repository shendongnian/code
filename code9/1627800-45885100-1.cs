    static void Main(string[] args)
    {
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
