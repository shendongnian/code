    namespace ExtensionMethods
    {
      public static class Utilities
      {
        public static bool ValueEndsWith(this Key key, ref string valueToCheck)
        {
          return key.Id.EndsWith(valueToCheck);
        } 
      }
    }
