    private static IEnumerable<string> ToChunks(string text, int size) {
      int n = text.Length / size + (text.Length % size == 0 ? 0 : 1);
      for (int i = 0; i < n; ++i)
        if (i == n - 1)
          yield return text.Substring(i * size);       // Last chunk
        else
          yield return text.Substring(i * size, size); // Inner chunk  
    }
    ...
    string FilePath = Path.Combine(strFullProcessedPath, strFileName);
    // Read once, do not Replace ao do something with the string
    string text = File.ReadAllText(FilePath);
    // ... but extracting 2000 char chunks
    File.WriteAllLines(FilePath, ToChunks(text, 2000));
