    private void button1_Click(object sender, EventArgs e)
    {
        using (SqlConnection test = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\Visual Studio 2015\\Projects\\SavetoDbTest\\SavetoDbTest\\Hobbie.mdf;Integrated Security=True")) 
        {
            using (SqlCommand again = new SqlCommand())
            {
                again.CommandText = "INSERT INTO Table Values(@Name,@Hobby)";
                again.Parameters.AddWithValue("@Name", textBox1.Text);
                again.Parameters.AddWithValue("@Hobby", comboBox1.Text);
                again.Connection = test;
                test.Open();
                again.ExecuteNonQuery();
                test.Close();
                MessageBox.Show("Data Entry Successful");
             }
        }      
    }
