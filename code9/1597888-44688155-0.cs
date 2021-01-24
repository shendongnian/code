      public IEnumerable<BuildNotes_op> RetrieveBuildDetails(string BuildID)
        {
           
            var conn = new MySql.Data.MySqlClient.MySqlConnection();
             var conn2 = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = AciDev.aciDevConnectionString;
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = @"query1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader(); --> **rdr open here**
                ....
    
                while (rdr.Read())
                {
                    .....
                    if (rdr[4] != DBNull.Value)
                        ....................
                    else
                         ........
                         string sql_get_latest_build_notes_cmd = "query2";
                         
                         conn2.ConnectionString = AciDev.aciDevConnectionString;
    
                     Console.WriteLine("Connecting to MySQL...");
                      conn2.Open();
                         MySqlCommand get_latest_build_notes_cmd = new MySqlCommand(sql_get_latest_build_notes_cmd, conn2);
                         MySqlDataReader rdr_get_latest_build_notes = get_latest_build_notes_cmd.ExecuteReader();  --> **throws exception here**
                         if (rdr_get_latest_build_notes.HasRows)
                        {
                          ....................
    
                        }
                         rdr_get_latest_build_notes.Close();
                        conn2.Close();
                    if (BuildDetails != null)
                    {
                        BuildNotesDetails.Add(BuildDetails);
                    }
                }
                rdr_get_latest_build_notes.Close();
                rdr.Close();
                conn.Close();
                conn2.Close();
                return BuildNotesDetails;
            }
    
            catch
            {
                throw;
            }
            finally
            {
                rdr_get_latest_build_notes.Close();
                rdr.Close();
                conn.Close();
                conn2.Close();
            }
