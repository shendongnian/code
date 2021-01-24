    var trie = new Trie();
    using (var fs = new System.IO.FileStream("path", FileMode.CreateNew, 
    FileAccess.Write))
    {
        var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        bf.Serialize(fs, trie);
    }
