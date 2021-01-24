     public static partial class StringExtensions {
       public static string ToStringHex(this string value) {
         if (null == value)
           return null; // Or throw ArgumentNullException
         if (string.IsNullOrEmpty(value))
           return "";   // Or throw ArgumentException
         // Let's be nice and let 0x... strings
         if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
           value = value.Substring(2);
         if (value.All(c => c >= '0' && c <= '9' || 
                            c >= 'a' && c <= 'f' || 
                            c >= 'A' && c <= 'F')) 
           return $"0x{value.ToLowerInvariant()}";
         throw new ArgumentException("Incorrect value format", "value"); 
       }
     }
...
     String s0 = "aaaAa"; 
     String result = s0.ToStringHex();    
