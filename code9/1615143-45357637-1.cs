    var trie = new Trie();
    using (var fs = new System.IO.FileStream("path", FileMode.CreateNew, FileAccess.Write, FileShare.None))
    {
        Type objType = typeof (Trie);
        var xmls = new XmlSerializer(objType);
        xmls.Serialize(fs, trie);
    }
