    int    DataID = 1234;
    string Data1  = "foo æøåè bar";
    string Data2  = "qux quee";
    
    List<byte> buffer = new List<byte>(BitConverter.GetBytes(DataID));
    buffer.Reverse(); // swap endianness for int
    buffer.AddRange(Encoding.Unicode.GetBytes(Data1 + "/"));
    buffer.AddRange(Encoding.Unicode.GetBytes(Data2));
    
    using (MD5 md5 = MD5.Create())
    {
        byte[] hashBytes = md5.ComputeHash(buffer.ToArray());
    
        //...
    }
