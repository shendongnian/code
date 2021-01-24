    public static void Test(string path){
        // If there is no File at the desired location
        if (File.Exists(path) == false){
        }
        // Get the FullPath
        string fullPath = Path.GetFullPath(path);
        // Check the Extension for .pdf
        if (path.EndsWith(".pdf")){
        }
        // Or you can do Path.GetExtension(path)
    }
