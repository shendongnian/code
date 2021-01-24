        var newCollection =  collection.OrderBy((s) =>
         {
            if (s.Contains("]"))
            {
               string pattern = "\\[(.*?)\\] ";
               Regex rgx = new Regex(pattern);
               return rgx.Replace(s, "");
            }
            else
            {
               return s;
            }
         }).ToList();
      }
