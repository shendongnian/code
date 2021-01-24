      // static: you have no need in "this"
      public static string RemoveSuffix(string word) {
        return word == null // <- do not forget to validate public method's argument(s)
          ? null            // or throw ArgumentNullException      
          : word.TrimEnd('ی'); 
      }
