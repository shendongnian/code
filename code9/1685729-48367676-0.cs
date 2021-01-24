    static void Main(string[] args)
    {
        string path = @"C:\path\kilroy_was_here.mp3";
        // instantiate the Application object
        dynamic shell = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"));
        
        // get the folder and the child
        var folder = shell.NameSpace(Path.GetDirectoryName(path));
        var item = folder.ParseName(Path.GetFileName(path));
        
        // get the item's property by it's canonical name. doc says it's a string
        string bpm = item.ExtendedProperty("System.Music.BeatsPerMinute");
        Console.WriteLine(bpm);
    }
