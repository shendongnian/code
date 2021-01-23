        String constring = "datasource=localhost;port=3306;Initial Catalog = 'svms'; username = svms; password =svms2016CPU";
        string query = "select * from studentinformation where StudLname='" + metroTextBox1.Text + "'";
        MySqlConnection conDataBase = new MySqlConnection(constring);
        MySqlCommand cmdDataBase = new MySqlCommand(query, conDataBase);
        //
        conDataBase.Open();
        //
        MySqlDataReader myReader = cmdDataBase.ExecuteReader();
