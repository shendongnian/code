    private void RefreshBtn_Click(object Sender, EventArgs e) {
        int InsertQuantity;
        using (SqlConnection conn = new SqlConnection(strConnection)) {
            using (SqlCommand cmd = new SqlCommand()) {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT Alert(Vehicle_no) SELECT Vehicle_no FROM Entry WHERE arrival_time <= GetDate()";
                try {
                    conn.Open();
                    InsertQuantity = cmd.ExecuteNonQuery();
                }
                catch {
                    InsertQuantity = -1;
                    // whatever error handling you need
                }
                finally { conn.Close(); }
            }
        }
        // InsertQuantity will tell you how many "alerts" were added
        // If  = -1 then there was an error
    }
