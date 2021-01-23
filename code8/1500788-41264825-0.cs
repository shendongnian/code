    for (int i = 0; i < sLines.Length; i++)
    {
         if (sLines[i].SValue == "" && i > 0)
         {
             Value = sLines[i-1].SValue;
         }
         else
         {
             Value = sLines[i].SValue;
         }
    }
