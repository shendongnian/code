    private DataTable InsertABlankRow(DataTable dt)
    {
       int n = dt.Rows.Count;
       DataTable dtnew = dt.Copy();
       if (dt.Columns.Contains("colname"))
       {
         var countRows = dt.Select("colname ='xyz'").Length;
         if (countRows > 1)
         {
          for(int i =0; i< dtnew.Rows.Count; i++)
           {
            if (dtnew.Rows[i]["colname"].ToString() == "xyz")
             {
              dt.Rows.InsertAt(dt.NewRow(), i+1);              
             }
            }
           dt.AcceptChanges();
          }
       }
    return dt;
    }
