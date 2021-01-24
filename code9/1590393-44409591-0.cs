    private void btnSearch_Click(object sendoer, RoutedEventArgs e)
    {
        bgw.WorkerReportsProgress = true;
        bgw.ProgressChanged += ProgressChanged;
        bgw.DoWork += DoWork;
        bgw.RunWorkerCompleted += BGW_RunWorkerCompleted;
        myProgressBar.Visibility = Visibility.Visible;
        bgw.RunWorkerAsync();
    }
    private void DoWork(object sender, DoWorkEventArgs e)
    {
        List<object> results = new List<object>();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM " + MyTableName, conn))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        results.Add(new
                        {
                            Id = rdr.GetInt32(0),
                            Name = rdr.GetString(1).ToString(),
                        });
                    }
                }
            }
        }
        e.Result = results;
    }
    private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        myDataGrid.ItemsSource = e.Result as List<object>;
        myProgressBar.Visibility = Visibility.Collapsed;
    }
