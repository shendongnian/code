            [System.Web.Services.WebMethod]
            public static void fillfields(string input)
            {
                string constr = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(constr))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("TMS_INSERT", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@EMP_ID", input);
                        command.ExecuteNonQuery();
                    }
                    //myinput1.Value = string.Empty;
                    connection.Close();
                }
            }
