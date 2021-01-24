    //using defaults and...
    using System.Data.OleDb;
    using System.Diagnostics;
    
         private void GetValues()
            {
                OleDbDataAdapter da = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                da.Fill(ds);
                Int32 index = 0; //index of the column you need
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    String result = row[index].ToString();
                    Debug.Print(result);
                }
            }
