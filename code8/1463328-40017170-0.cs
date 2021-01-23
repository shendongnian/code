       DataSet ds = new DataSet("dts");
        using(SqlConnection conn = new SqlConnection
          ("Data Source=;Initial  Catalog=;User ID=;Password="))
            {               
         SqlCommand sqlComm = new SqlCommand("usp_FCS_GetUnitInfo_Takaya",conn);               
            sqlComm.Parameters.AddWithValue("@p1", MachineName);
            sqlComm.Parameters.AddWithValue("@p2", "serial");
       
            sqlComm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(ds);
          }
