     foreach (string row in File.ReadAllLines(fullPath))
     {
       if (!string.IsNullOrEmpty(row))
       {
         dt.Rows.Add();
         int i = 0;
         foreach (string cell in row.Split('\t'))
         {
           dt.Rows[dt.Rows.Count - 1][i] = cell;
           i++;
         }
       }
     }
