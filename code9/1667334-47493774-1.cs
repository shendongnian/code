        string GetDecryptedData(string s)
        {
           StringBuilder s = new StringBuilder();
           foreach(char c in s.ToCharArray()
           {
               s.Append(dict.FirstOrDefault(x => x.Value == c).Key;);
           }
           return s.ToString();
         }
