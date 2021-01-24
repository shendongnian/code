    Private void button1_Click(object sender, EventArgs e)
    {
        string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
        conn.open();  //Open Connection
            using (SqlCommand cmd = new SqlCommand("ups_StudentInsertDetails",conn)) //Pass connection to thesqlcommand
            {
                cmd.Parameters.AddWithValue("Name", textBox1.Text);
                cmd.Parameters.AddWithValue("Email", textBox2.Text);
                //then open connection
                //Execute Reader(select ststement)
                //Execute Scalar(select ststement)
                //Executenonquery (Insert , update or delete)
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data saved successfully!");
            }
        }
    }
}
