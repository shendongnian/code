    private void bttnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            int index = Convert.ToInt32(e.RowIndex);
            string query = "delete from tblBookMaint where BookNumber= "+index+" ";
            command.CommandText = query;
            command.ExecuteNonQuery();
            MessageBox.Show("Data Deleted!");
            connection.Close();
            load();
            clearTxts();
            Panel.Enabled = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error " + ex);
        }
    }
