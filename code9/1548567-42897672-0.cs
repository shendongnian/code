    [WebMethod]
           public DataTable searchCom(string compCode)
           {
              try
                {
                SqlConnection conn = new SqlConnection("Data Source=LOCALPC\\SQLEXPRESS1; Initial Catalog=Company;Integrated Security=True;");
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("selectPress", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add("@item", SqlDbType.VarChar).Value = compCode;
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt); 
                return dt;
               }
               catch (Exception ex)
               {
                 throw new SoapException("Exception :",   
                 SoapException.ServerFaultCode, "SoapException", ex);
               }
           }
