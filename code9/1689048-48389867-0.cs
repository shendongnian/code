    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\UniversityDataBase.mdf;Integrated Security=True");
            string sqlQuery = "SELECT *FROM TutorTable WHERE Tid = '" + comboBox1.Text + "'";
            SqlCommand objCommand = new SqlCommand(sqlQuery, con);
            con.Open();
            SqlDataReader dr;
            dr = objCommand.ExecuteReader();
            while (dr.Read())
            {
                string name = (string)dr["Tname"].ToString();
                textBox1.Text = name;
            }
        }
