    if (myReader3.HasRows)
    {
         DataTable dt = new DataTable();
         dt.Load(myReader3);
    
         for (int i = 0; i < dt.Rows.Count; i++)
         {
             // label assignments here
         }
    }
