    using (var fs = new FileStream("Path", FileMode.Open, FileAccess.Read))
    {
            var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            return bf.Deserialize(fs) as Trie;
    }
