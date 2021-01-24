    Dictionary<string, long> lengthByFilename = new Dictionary<string, long>();
    // TODO: recurse through all existing files to get their lengths and put in 
    //       the dictionary
    watcher.Changed.Select(x => {
        string addedContent;
        using (var file = File.OpenRead(x.Name)) {
            // Seek to the last known end position
            if (lengthByFilename.ContainsKey(x.Name)) {
                file.Seek(lengthByFilename[x.Name], SeekOrigin.Begin);
            }
            
            using (var reader = new StreamReader(file)) {
                addedContent = reader.ReadToEnd();
            }
        }
        
        // Update dictionary with new length
        lengthByFilename[x.Name] = (new FileInfo(x.Name)).Length;
        
        return $"{x.Name} has had this added: {addedContent}";
    }).Subscribe(Console.WriteLine);
