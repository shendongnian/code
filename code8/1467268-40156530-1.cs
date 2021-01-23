      public enum Values {
        True,
        False,
        // and, probably, some other options
      };
    
      public static class ValuesExtensions {
        public static bool ToBoolean(this Values value) {
          // which options should be treated as "true" ones
          return value == Values.False;
        }
      }
...
    // you, probably want to check if UIHelper.Values is the same as values 
    if (values == UIHelper.Values.ToBoolean()) {
      ...
    }
