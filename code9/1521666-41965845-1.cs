    int n = 3;
    byte newValue = 0xFF;
    for (int i = n; i < listBytes.Count; i += n)
    {
      listBytes[i] = newValue;
    }
    
    File.WriteAllBytes(path, listBytes.ToArray());
