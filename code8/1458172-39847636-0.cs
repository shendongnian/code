    private  void Write(System.Data.DataSet dts, string outputFilePath)
    {
       System.Data.DataTable dt = new System.Data.DataTable();
       for (int z = 0; z < dts.Tables.Count; z++)
       {
         dt = dts.Tables[z];
         int[] maxLengths = new int[dt.Columns.Count];    
         for (int i = 0; i < dt.Columns.Count; i++)
         {
           maxLengths[i] = dt.Columns[i].ColumnName.Length;    
           foreach (DataRow row in dt.Rows)
           {
             if (!row.IsNull(i))
             {
               int length = row[i].ToString().Length;    
                if (length > maxLengths[i])
                {
                  maxLengths[i] = length;
                }
              }
           }
         }
    
       using (StreamWriter sw = new StreamWriter(outputFilePath, true))
        {     
        for (int i = 0; i < dt.Columns.Count; i++)
         {
                                sw.Write(dt.Columns[i].ColumnName.PadRight(maxLengths[i] + 2));
         }    
         sw.WriteLine();    
          foreach (DataRow row in dt.Rows)
          {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
              if (!row.IsNull(i))
              {
                                        sw.Write(row[i].ToString().PadRight(maxLengths[i] + 2));
              }
              else
              {
               sw.Write(new string(' ', maxLengths[i] + 2));
              }
            }    
          sw.WriteLine();
        }  
        sw.Close();
      }
     }
    }
