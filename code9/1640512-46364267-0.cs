      using System.Linq;
      ... 
      string source = "abc    \t def\r\n789";
      string result = string.Concat(source.Where(c => !char.IsWhiteSpace(c)));
      Console.WriteLine(result);
