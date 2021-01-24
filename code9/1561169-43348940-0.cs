     private BackgroundWorker bw = new BackgroundWorker();
     private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
          populate();
      
    }
    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        prg2.Visibility = Visibility.Hidden;    
    }
    private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                bw.WorkerReportsProgress = true;
                bw.DoWork += bw_DoWork;
                //bw.ProgressChanged += bw_ProgressChanged;
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;
			    prg2.Visibility = Visibility.Visible;
                bw.RunWorkerAsync();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
		
     private void populate ()
     {
            using (SqlConnection con= new SqlConnection(connectionstring))
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd= new SqlCommand("Select ...", con);
                cmd.CommandTimeout = 0;
                SqlDataAdapter _dadapt= new SqlDataAdapter();
                _dadapt.Fill(dt); 
                con.Close();
				Application.Current.Dispatcher.Invoke(new Action  (() =>
					{
					dataGrid1.itemsSource = dt.DefaultView;
					}));
            }
      }
