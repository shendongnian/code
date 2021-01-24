    [WebMethod]
        //Remove static
        public string GetCustomers()
        {
            string query = "SELECT Count(*) FROM Devices";
            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(DbConnect.ConnectStr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds);
                        //Return only count string
                        return ds.Tables[0].Rows[0]["Count"].ToString();
                    }
                }
            }
        }
