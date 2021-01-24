    int x = 0;
        foreach (DataRow row in records.Rows) // Out of Memory Exception Here
        {
            x = x + 1;
            if(x > records.Rows.Length)
            {
              break; 
            }
            var fields = row.ItemArray.Select(field = "\"" + field.ToString().Replace("\"", "\"\"") + "\"").ToArray();
            sUrl.WriteLine(string.Join("\t", fields));
        }
