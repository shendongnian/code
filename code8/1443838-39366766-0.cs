    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection test = new SqlConnection("YourConnectionStringName"))
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
        catch (Exception ex)
        {   
            throw ex;
        }
    }
