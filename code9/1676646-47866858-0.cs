    using System.Linq;
    ...
    public static string cypher(string word) {
      //DONE: do not forget to validate public method's arguments
      if (string.IsNullOrEmpty(word))
        return word;
    
      //TODO: you may want to make some amendments
      //  1. Filter out which characters to encode (e.g. skip new lines)
      //  2. Add modulo operator (e.g. to encode letters as letters)
      return string.Concat(word.Select(d => (char)(d + 2))); 
    } 
