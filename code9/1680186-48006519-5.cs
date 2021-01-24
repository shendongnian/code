    void Main()
    {
    	
    List<string> ext = new List<string> { ".jpg", ".jpeg", ".png", ".gif", ".tif" }; 
    FileInfo[] files = new DirectoryInfo(@"c:\temp").EnumerateFiles("*.*", SearchOption.AllDirectories) 
    .Where(path => ext.Contains(Path.GetExtension(path.Name))) 
    .Select(x => new FileInfo(x.FullName)).ToArray();
    }
    
    // Define other methods and classes here
