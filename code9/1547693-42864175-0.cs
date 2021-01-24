    System.IO.FileStream stream = 
        new FileStream(@"C:\file.pdf", FileMode.CreateNew);
    System.IO.BinaryWriter writer = 
        new BinaryWriter(stream);
    writer.Write(base64TextBytes, 0, base64TextBytes.Length);
    writer.Close();
