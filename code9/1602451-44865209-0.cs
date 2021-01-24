       public static class StringComparisonExtensions {
         public static bool IsCaseSensitiveUsing(this StringComparison value) {
           return (value == StringComparison.CurrentCulture || 
                   value == StringComparison.InvariantCulture || 
                   value == StringComparison.Ordinal); 
         }
       } 
       ....
       StringComparison myComparison = ...
       // Check as if StringComparison has IsCaseSensitiveUsing method:
       if (myComparison.IsCaseSensitiveUsing()) {
         ...
       }
