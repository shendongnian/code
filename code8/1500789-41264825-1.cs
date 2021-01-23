    for (int i = 0; i < sLines.Length; i++)
    {
         if (sLines[i].SValue == "" && i > 0)
         {
             sLines[i].SValue = sLines[i-1].SValue;
         }
         else
         {
             sLines[i].SValue = sLines[i].SValue;
         }
    }
