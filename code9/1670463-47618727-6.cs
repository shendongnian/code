        public static string ReplaceIndex(this string self, string OldString, string newString, int index)        
        {
            return self.Remove(index, OldString.Length).Insert(index, newString); 
        }
      // ...
      s = s.ReplaceIndex(m.Groups(1).Value, "newString", m.Index)
      // ...
