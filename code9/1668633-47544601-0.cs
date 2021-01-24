    using (FileStream file = new FileStream(@"c:\folder\path\file.ext", FileMode.Create, System.IO.FileAccess.Write)) 
    {
      byte[] bytes = new byte[streams.Length];
      streams.Read(bytes, 0, (int)streams.Length);
      file.Write(bytes, 0, bytes.Length);
      streams.Close();
    }
