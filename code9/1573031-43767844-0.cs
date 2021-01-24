    int RowsAffected;
    using (SqlConnection conn = new SqlConnection(strConn)) {
        string cmdText = "insert into xxx(col1, col2) values(@col1,@col2)";
        using (SqlCommand cmd = new SqlCommand(cmdText, conn)) {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@col1", "val1");
            cmd.Parameters.AddWithValue("@col2", "val2");
            try {
                conn.Open();
                RowsAffected = cmd.ExecuteNonQuery();
            }
            catch (SqlException sx) {
                RowsAffected = -1;
                Console.Write(sx); // your SQL error handling
            }
            catch (Exception ex) {
                RowsAffected = -2;
                Console.Write(ex); // other exception handling
            }
            finally {
                    // your cleanup routines
                    conn.Close();
                    Console.Write("Rows Added = " + RowsAffected);
                }
            }
        }
   
