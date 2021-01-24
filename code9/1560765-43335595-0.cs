    if (ds.Tables.Count > 0)
     {
          if (ds.Tables[0].Rows.Count > 0)
          {
             //Then Return a value here or Get the date
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        String getFirstRow = dr[0].ToString();
                        //And so on........
                    }
          }
          else
          { 
                //Return value if no rows found.
          }
     }
