     public static class StringExtension
     {
         public static string ToCamelCase(this string str)
         {                    
             if(!string.IsNullOrEmpty(str) && str.Length > 1)
             {
                 return Char.ToLowerInvariant(str[0]) + str.Substring(1);
             }
             return str;
         }
     }
     //Or
     public static class StringExtension
     {
         public static string ToCamelCase(this string str) =>
             return string.IsNullOrEmpty(str) || str.Length < 2
             ? str
             : Char.ToLowerInvariant(str[0]) + str.Substring(1);
     }
