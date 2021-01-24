    [WebMethod]
            public DataSet searchCom(string compCode)
           {
                SqlConnection conn = new SqlConnection("Data Source=LOCALPC\\SQLEXPRESS1; Initial Catalog=Company;Integrated Security=True;");
                conn.Open();
                DataSet dt = new DataSet();
                SqlCommand cmd = new SqlCommand("selectPress", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add("@item", SqlDbType.VarChar).Value = compCode;
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt); 
                return dt;
           }
