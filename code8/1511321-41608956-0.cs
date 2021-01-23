     void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is DataTable)
                {
                    WMI_grid.ItemsSource = ((DataTable)e.Result).DefaultView;
                }
                else if (e.Result is Exception)
                {
                }
    
            }
