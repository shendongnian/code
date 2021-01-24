    using (var archive = ZipFile.Open("Test.zip", ZipArchiveMode.Update))
    {
        StringBuilder document;
        var entry = archive.GetEntry("foo.txt");//entry contents "foobar123"
        using (StreamReader reader = new StreamReader(entry.Open()))
        {
           document = new StringBuilder(reader.ReadToEnd());
        }
        
        entry.Delete();
        entry = archive.CreateEntry("foo.txt");
        document.Replace("foobar", "baz"); //builder contents "baz123"
    
        using (StreamWriter writer = new StreamWriter(entry.Open()))
        {
           writer.Write(document);
        }
    }
