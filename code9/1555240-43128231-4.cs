    Dictionary<string, char> decode = keys
      .ToDictionary(pair => pair.Value, pair => pair.Key);
    int fixedSize = decode.First().Key.Length;
    string decoded = string.Concat(Enumerable
      .Range(0, result.Length / fixedSize)
      .Select(i => decode[result.Substring(i * fixedSize, fixedSize)]));
    
