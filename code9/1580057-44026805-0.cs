    string query3 = "SELECT Count(*) FROM Sonuc WHERE sinavno = @sinavno";
    Int64 result3;
    using(MySqlCommand cmd3 = new MySqlCommand(query3, mdl.mysqlbaglan)) {
        cmd3.Paramaters.AddWithValue("@sinavno", sinavno);
        try {
            mdl.mysqlbaglan.Open();
            result3 = (Int64)cmd3.ExecuteScalar();
        }
        catch (Exception ex) {
            result3 = -1;
            // your exception handling
        }
        finally {
            mdl.mysqlbaglan.Close();
            // any other cleanup
        }
    }
    MessageBox.Show(result3.ToString());
