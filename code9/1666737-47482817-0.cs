        void ExecuteQuery()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            progressBar_Copy.Visibility = Visibility.Visible;
            worker.RunWorkerAsync(tbUsername.Text);
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string username = e.Argument as string;
            if (!string.IsNullOrEmpty(username))
            {
                using (SqlConnection con = new SqlConnection(ConString))
                using (SqlCommand cmd = new SqlCommand("tblProbaSelect", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        try
                        {
                            con.Open();
                            adapter.Fill(dt);
                            e.Result = dt;
                        }
                        catch (Exception ex)
                        {
                            e.Result = ex;
                        }
                    }
                }
            }
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                MessageBox.Show(((Exception)e.Result).Message);
            }
            else
            {
                DataTable dt = e.Result as DataTable;
                if (dt != null)
                    tabela.ItemsSource = dt.DefaultView;
            }
            progressBar_Copy.Visibility = Visibility.Hidden;
        }
