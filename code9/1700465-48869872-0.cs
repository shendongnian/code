    public override void PostExecute()
        {
            base.PostExecute();
    
            conn.Close();
  
        }
----------
    public override void Input0_ProcessInputRow(Input0Buffer Row)
        {
            if(conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            System.Data.SqlClient.SqlCommand cmd = new
                System.Data.SqlClient.SqlCommand("[dbo].[spEximLog]", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@pSystemID", Row.Id));
            cmd.Parameters.Add(new SqlParameter("@pSource", Row.source));
            cmd.Parameters.Add(new SqlParameter("@pstarttime", Row.starttime));
            cmd.Parameters.Add(new SqlParameter("@pendtime", Row.endtime));
            cmd.Parameters.Add(new SqlParameter("@pmessage", Row.message));
    
            cmd.ExecuteNonQuery();
        }
