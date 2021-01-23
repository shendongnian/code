    public void FileProcessDirectory(string targetDirectory, string subfolder)
    {
        // this adds files
        foreach (string fileName in Directory.GetFiles(targetDirectory))
        {
            FileProcessFile(fileName);
        }
        
        // if we pass subfolder as empty then nothing happens
        if(string.IsNullOrEmpty(subfolder)) return;
        // here we find our subfolder and display files for it        
        FileProcessDirectory(Directory.GetDirectories(targetDirectory).Where(d => d == targetDirectory + "\\" + subfolder).ToArray()[0], null);
    }
