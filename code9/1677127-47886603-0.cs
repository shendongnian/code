    public class DbCrud
    {
       public bool SaveData(DateSet ds)
       {
         //create data adapter object with required connection information
         // and just call save here 
          sqlCnn.Open();
          sqlCmd = new SqlCommand(sql, sqlCnn);
          adapter.SelectCommand = sqlCmd;
          adapter.Update(ds);
       }
    }
