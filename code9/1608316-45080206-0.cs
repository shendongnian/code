      using using System.Text.RegularExpressions;
      ...
      string source = @"hello there, compiler.";
      string result = string.Concat(Regex
        .Split(source, @"(\W+)") // split on not word letter, separator preserved
        .Select(letter => letter.Length > 0 && char.IsLetter(letter[0]) 
           ? string.Concat(letter.Reverse()) // reverse letter
           : letter));                       // keep separator intact 
      Console.Write(result);
