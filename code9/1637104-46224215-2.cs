        comboBox1.Items.Add("Select product");
        using (SqlConnection con = createconnection()) {
            using (SqlCommand cmd = new SqlCommand ("SELECT Pname FROM product")) {
                using (SqlDataReader reader = cmd.ExecuteReader ()) {
                    while (reader.Read ()) {
                        comboBox1.Items.Add (Convert.ToString (reader[0]));
                    }
                }
            }
        }
