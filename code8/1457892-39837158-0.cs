      static void SplitValAndUnit(string unsplitData)
      {
         for (int x = 0; x < unsplitData.Length; x++)
         {
            if (Char.IsLetter(unsplitData[x]))
            {
               string value = unsplitData.Substring(0, x);
               // TryParse value to whatever data type
               string unit  = unsplitData.Substring(x, unsplitData.Length - x);
            }
         }
      }
