    using (SqlConnection conn = new SqlConnection(lemars._LeMarsConnectionString))
    {
         reader = null;
         SqlCommand Sqlcmd = new SqlCommand(SqlcmdString, conn);
         conn.Open();
         reader = Sqlcmd.ExecuteReader();
         if (reader.HasRows)
         {
             try
             {
                 DataTable dt = new DataTable();
                 dt.Load(reader);
    
                 for (int i = 0; i < dt.Rows.Count; i++)
                 {
                     Obj.Invoice = dt.Rows[i]["invoice"].ToString();
                     Obj.Shipment = dt.Rows[i]["shipment"].ToString();
                     Obj.Project = dt.Rows[i]["Project"].ToString();
    
                     // other stuff
                 }
             
                 dataGridView.DataSource = dt;
             }
             finally
             {
                 conn.Close();
             }
         }
    }
