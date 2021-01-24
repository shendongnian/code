    private void button1_Click(object sender, EventArgs e)
    {
        connection.Open();
        string query = "Delete from Hoteldb where ID='" + textBox0.Text + "'";
        command = new OleDBCommand(query);
        command.Connection = connection;
        command.ExecuteNonQuery();
        MessageBox.Show("Guest Checked Out succesfly");
        BindGridView();
    }
