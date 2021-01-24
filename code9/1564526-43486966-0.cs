     for (var r = 0; r < dt.Rows.Count; r++)
     {
       for (var c = 0; c < dt.Columns.Count; c++)
         {
           if (dt.Columns[c].DataType.Name == "String" || dt.Columns[c].DataType.Name == "DateTime")
              wr.Write( "'" + dt.Rows[r][c].ToString().Trim());
            else
              wr.Write( dt.Rows[r][c]);
          }
      }     
