    public class Demo
    {
        public void Example()
        {
            string connString = ConfigurationManager.ConnectionStrings["TestDatabase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string cmdUpdate = "UPDATE mem SET name =@name";
                string cmd = "SELECT * FROM mem;";
                SqlCommand comm = new SqlCommand(cmd, conn);
                SqlCommand commUpdate = new SqlCommand(cmdUpdate, conn);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    comm.Parameters.Add(new SqlParameter() { ParameterName = "@name", DbType = System.Data.DbType.String });
                    while (dr.Read())
                    {
                        DateTime date = DateTime.ParseExact(dr["date"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        if (date < DateTime.UtcNow)
                        {
                            commUpdate.Parameters["@name"].Value = "Done";
                            comm.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
    
        }
    }
