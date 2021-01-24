    string originalText = null;
    while (true)
    {
        try
        {
            originalText = File.ReadAllText(@"C:\Users\...\fileName.txt", Encoding.Default);
            break;
        }
        catch 
        { 
            System.Threading.Thread.Sleep(100);
        }
    }
