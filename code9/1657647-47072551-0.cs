        foreach (DataRow row in dt.Rows)
         {
           foreach (DataColumn col in dt.Columns)
             {
               var index = col.Ordinal+1; // Current column index
               if(index == dt.Columns.Count) // if column is last column in current row
                  {
                    your logice goes here
                  }
              }
         }
