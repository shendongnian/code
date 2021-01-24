    private void checkinbtn_Click(object sender, EventArgs e)
    {
        try
        {
            var cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE guestreg SET g_status='In House' where *name of primary key*=@id";
            cmd.Parameters.AddWithValue("@id", value);
            cmd.Connection = connection;
            connection.Open();
            cmd.ExecuteNonQuery();
            {
                MessageBox.Show("Update Success!");
                connection.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error:     " + ex);
        }
    }
