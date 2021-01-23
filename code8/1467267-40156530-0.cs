      public enum UnlPointValues {
        Serial,
        Service,
        // and, probably, some other options
      };
    
      public static class UnlPointValuesExtensions {
        public static bool ToBoolean(this UnlPointValues value) {
          // which options should be treated as "true" ones
          return value == UnlPointValues.Service;
        }
      }
...
    // you, probably want to check if UIHelper.UnlPointValues is the same as values 
    if (values == UIHelper.UnlPointValues.ToBoolean()) {
      ...
    }
