    private static IEnumerable<string> ReadChunks(string fileName, int size) {
      string text = File.ReadAllText(fileName);
 
      int n = text.Length / size + (text.Length % size == 0 ? 0 : 1);
            
      for (int i = 0; i < n; ++i) 
        if (i == n - 1)
          yield return text.SubString(i * size);       // Last chunk
        else        
          yield return text.SubString(i * size, size); // Inner chunk  
    }
    ...
    string FilePath = Path.Combine(strFullProcessedPath, strFileName);
    File.WriteAllLines(FilePath, ReadChunks(FilePath, 2000));
