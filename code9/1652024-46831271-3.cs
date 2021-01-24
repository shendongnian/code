      string source = "encrypt me, please!";
      string result = string.Concat(source
        .Select(c => dict.TryGetValue(c, out var cNew) // do we have a key?
           ? cNew // if true, put the corresponding value 
           : c)); // if false, leave the character intact
      Console.WriteLine(source);
      Console.WriteLine(result);
