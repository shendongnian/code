    private void button1_Click(object sender, EventArgs e)
    {
        connection.Open();
        command.Connection = connection;
        string query = " delete from Hoteldb where ID= '" +textBox0.Text + "'";
        MessageBox.Show(query);
        command.CommandText = query;
        command.ExecuteNonQuery();
        MessageBox.Show("Guest Checked Out succesfly");
        BindGridView();
    }
