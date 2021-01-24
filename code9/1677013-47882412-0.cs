    string genusInput = "Dog"; // might be provided by user input later on
    
    DataTable result = new DataTable();
    
    using (MySqlConnection con = new MySqlConnection(constring)) {
    
        const string query = "SELECT * FROM table1 WHERE Column2 = @genus";    
        var adp = new MySqlDataAdapter(query, con);
        adp.SelectCommand.Parameters.AddWithValue("@genus", genusInput);
        adp.Fill(result);
        adp.Dispose();
    }
