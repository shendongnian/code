    private void buttonConnect_Click(object sender, EventArgs e)
    {
        if (!backgroundWorker.IsBusy)
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = textBoxDataSource.Text;
            sqlConnectionStringBuilder.UserID = textBoxUserId.Text;
            sqlConnectionStringBuilder.Password = textBoxPassword.Text;
            sqlConnectionStringBuilder.InitialCatalog = textBoxInitialCatalog.Text;
    
    
            backgroundWorker.RunWorkerAsync(sqlConnectionStringBuilder);
        }
    }
