    public void Window_Closing(object sender, CancelEventArgs e)
    {
        var checkNoValue = ((DataProperties)gridView.SelectedItem).Check_No;
        var checkDateValue = ((DataProperties)gridView.SelectedItem).Check_Date;
        SqlConnection conn;
        SqlCommand comm;
        string connstring = "Server = testserver; Database = test; User Id = test; Password = somepassword;"
                conn = new SqlConnection(connstring);
        conn.Open();
        comm = new SqlCommand("insert into DeductionInfo (Check_No, Check_Date) values (@checkNoValue, @checkDateValue)", conn);
        comm.Parameters.AddWithValue("@checkNoValue", checkNoValue);
        comm.Parameters.AddWithValue("@checkDateValue", checkDateValue);
        comm.ExecuteNonQuery();
        comm.Dispose();
        conn.Dispose();
        MessageBox.Show("Saved");
    }
