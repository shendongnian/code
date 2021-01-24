        string GetEncryptedData(string s)
        {
           StringBuilder s = new StringBuilder();
           foreach(char c in s.ToCharArray()
           {
              s.Append(dict[c]);
           }
           return s.ToString();
         }
