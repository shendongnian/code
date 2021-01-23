    byte[] result;
    myClass my = new myClass()
    {
        Test = "a1",
        Value = 0
    };
    BinaryFormatter bf = new BinaryFormatter();
    using (MemoryStream ms = new MemoryStream())
    {
        bf.Serialize(ms, my); //NO MORE ERROR
        result = ms.ToArray();
    }
