    public static List<string> push_notify()
        {
            var no = "25/10/2017";
            var result = new List<string>();
            try
            {
                string connection = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString.ToString();
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "sampleone";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@createdOn",no);
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine();
                    for (int x = 0; x < dt.Columns.Count; x++)
                    {
                        var value = row[x].ToString();
                        Console.Write(value + " ");
                        result.Add(value);
                    }
                }
                con.Close();
                return result;
            }
            catch(Exception)
            {
                return result;
            }
        }
