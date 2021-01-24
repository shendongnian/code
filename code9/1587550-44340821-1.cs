    protected string GetPI()
         {
             int customerId = GetCustomerID(); // customer id - 123
             int year = Convert.ToInt32(ddlIdYear.SelectedValue);
             string PI = "PI/" + year + "/" + customerId;
             SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["JSSConnection"].ToString());
             con.Open();
             for (char i = 'A'; i <= 'Z'; i++)
             {
                PI = "PI/" + year + "/" + customerId + i; // PI - PI/2017/123
                //SqlDataReader myReader = null;
               
                SqlCommand cmd = new SqlCommand("CheckPI", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI", PI);
                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@Exists";
                outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                outputParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outputParameter);
                cmd.ExecuteNonQuery();
                int returnVal = Convert.ToInt32(outputParameter.Value.ToString());
                if (returnVal == 1)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
             //else
             //{
             //    PI = "PI/" + year + "/" + customerId;
             //}
             con.Close();
             //Response.Write(cmd.Parameters["@ReturnValue"].Value);
             return PI;
         
         }
