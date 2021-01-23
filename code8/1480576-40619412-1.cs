      private string Convert(string source)
      {
           string arabicWord = string.Empty;
           StringBuilder sbDestination = new StringBuilder();
        
           foreach (var ch in source)
           {
               if (IsArabic(ch))
                   arabicWord += ch;
               else
               {
                   if (arabicWord != string.Empty)
                        sbDestination.Append(Reverse(arabicWord));
                
                   sbDestination.Append(ch);
                   arabicWord = string.Empty;
                }
            }
        
            // if the last word was arabic    
            if (arabicWord != string.Empty)
                sbDestination.Append(Reverse(arabicWord));
        
            return sbDestination.ToString();
         }
    
    
         private bool IsArabic(char character)
         {
             if (character >= 0x600 && character <= 0x6ff)
                 return true;
        
             if (character >= 0x750 && character <= 0x77f)
                 return true;
        
             if (character >= 0xfb50 && character <= 0xfc3f)
                 return true;
        
             if (character >= 0xfe70 && character <= 0xfefc)
                 return true;
        
             return false;
         }
    
         // Reverse the characters of string
         string Reverse(string source)
         {
              return new string(source.ToCharArray().Reverse().ToArray());
         }
            
