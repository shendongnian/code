    var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
    using(var ms = new MemoryStream())
    {
      bf.Serialize(ms, new Human{ Age = 42, Weight = -1 });
      HexDump(ms.ToArray());
    }
