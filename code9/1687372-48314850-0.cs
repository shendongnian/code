    public void SDB()
    {
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        try
        {
            dt_main.Clear();
            myConnection.Open();
            command.Connection = myConnection;
            command.CommandText = "Select * from Genre with (nolock) order by code";                
            adapter.SelectCommand = command;
            adapter.Fill(dt_main);
            gridControl1.DataSource = dt_main;               
        }
        catch (Exception ex)
        {
            MessageBox.Show("error" + ex);
        }
        finally
        {
            myConnection.Close();
        }
    }
