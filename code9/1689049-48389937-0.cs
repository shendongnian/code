        string sqlQuery = "SELECT *FROM TutorTable where Tid = '"+comboBox1.Text+ "Convert.ToString()'";
        SqlCommand objCommand = new SqlCommand(sqlQuery, objConnection);
        objConnection.Open();
        objCommand.ExecuteNonQuery();
        SqlDataReader dr;
        dr = objCommand.ExecuteReader();
        while (dr.Read())
        {
            string Tname = (string)dr["Tname"].ToString();
            textBox1.Text = Tname;
        }
    }
