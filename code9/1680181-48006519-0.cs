    void Main()
    {
    	var ext = new List<string> {"jpg", "gif", "png"};
    var myFiles = Directory.GetFiles(@"C:\temp", "*.*", SearchOption.AllDirectories)
    	 .Where(s => ext.Contains(Path.GetExtension(s)));
    }
    
    // Define other methods and classes here
