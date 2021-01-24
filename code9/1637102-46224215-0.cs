        AutoCompleteStringCollection mycol = new AutoCompleteStringCollection {
            "Select product"
        };
        using (SqlConnection con = createconnection()) {
            using (SqlCommand cmd = new SqlCommand ("SELECT Pname FROM product")) {
                using (SqlDataReader reader = cmd.ExecuteReader ()) {
                    while (reader.Read ()) {
                        mycol.Add (Convert.ToString (reader[0]));
                    }
                }
            }
        }
        comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        comboBox1.AutoCompleteCustomSource = mycol;
