    try{
    string strQuery = ("Update tblTransactionItems set selected = 'T' Where SeatNumber = @SeatNumber");
    con.Open();
    foreach (var item in list) {
      using (SqlCommand cmd = new SqlCommand(strQuery, con)) {
    string test = item.ToString();
    test = test.Replace('"', ' ').Trim();
    cmd.Parameters.AddWithValue("@SeatNumber", test);
    cmd.ExecuteNonQuery();
      }
    }
    }
    finally{ con.Close() }
