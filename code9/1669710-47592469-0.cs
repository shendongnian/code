    DataTable table = new DataTable();
    // get data from access
    using(OleDbConnection conn = new OleDbConnection("connString1"))
    {
         using(OleDbDataAdapter da = new OleDbDataAdapter(@"SELECT * FROM MyTable", conn))
               da.Fill(table);
    }
    
    //insert data into Sql server:
    using(SqlConnection conn = new SqlConnection("connString2"))
    {
         using(SqlCommand cmd = new SqlCommand())
         {
                cmd.CommandText = @"INSERT INTO MyTable VALUES (@p1, @p2, @p3)";
                 cmd.Connection = conn;
                 cmd.Parameters.Add("@p1", SqlDbType.Int);  
                 cmd.Parameters.Add("@p2", SqlDbType.CarChar, 50);
                 cmd.Parameters.Add("@p3", SqlDbType.DateTime);
                 conn.Open();
              
                 for(int i = 0; i < table.Rows.Count; i++)
                 {
                        cmd.Parameters["@p1"].Value = Convert.ToInt32(table.Rows[i][0]);
                        cmd.Parameters["@p2"].Value = table.Rows[i][1].ToString();
                        cmd.Parameters["@p3"].Value = Convert.ToDateTime(table.Rows[i][2]);
                        try
                        {
                              cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                               MessageBox.Show(ex.Message);
                               break;
                        }
                 }
         }
    }
