     string path = @"C:\testlog.log";
                String connectionString = ConfigurationManager.ConnectionStrings["MYDB_Conn"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // sholud be here
    
                    string query = "SELECT RawImportEnabled, ImportDayTimeStamp from Settings";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    { 
                        String RawImportEnabled = Convert.ToString(reader["RawImportEnabled"]);
                        //Do some thing
                    }
                }
