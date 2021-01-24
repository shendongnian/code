      public static string Encrypt(string source) {
        if (null == source)
          return null; // or throw ArgumentNullException  
        // out var - C# 7.0 syntax
        return string.Concat(source
          .Select(c => s_Dict.TryGetValue(c, out var cNew) // do we have a key?
             ? cNew // if true, put the corresponding value 
             : c)); // if false, leave the character intact
      }
