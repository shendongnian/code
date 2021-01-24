    string strQuery = ("Update tblTransactionItems set selected = 'T' Where SeatNumber = @SeatNumber");
        
        using (SqlCommand cmd = new SqlCommand(strQuery, con)) {
        con.Open();
        foreach (var item in list) {
            string test = item.ToString();
            test = test.Replace('"', ' ').Trim();
            cmd.Parameters.AddWithValue("@SeatNumber", test);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
