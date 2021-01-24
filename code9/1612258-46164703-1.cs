    // using System.IO;        
    void Initialize()
    {
        if(!Directory.Exists("logs"))
        {
            Directory.CreateDirectory("logs");
        }
    }
