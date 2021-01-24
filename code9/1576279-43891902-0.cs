      static int CountArticles(string text)
      {
          int count = 0;
          for (int i = 0; i < text.Length; ++i)
          {
              if (text[i] == 'a' || text[i] == 'A')
              {
                 // So we have a or A, now we have to check for spaces:
                 if (((i == 0) || char.IsWhiteSpace(text[i - 1])) &&
                     ((i == text.Length - 1) || char.IsWhiteSpace(text[i + 1])))
                    ++count;
               }
           }            
      
           return count;
      } 
