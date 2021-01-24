    public static DataSet ds_input;
        private void btn_process_Click(object sender, EventArgs e)
        {
            //some code here to fetch data and call backgroundworker
            backgroundWorker1.RunWorkerAsync(ds);
        }
    
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {               
            bool success = false;
            do
            {
                try
                {
                    e.Result = check_number(ds_input);
                    success = true;
                }
                catch (System.Net.WebException ex)
                {
                   success = false;
                }
               
            }while(!success);
        }
    
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
                int i = e.ProgressPercentage;
                int j = showProgress(i, Total_Record);
                lbl_counter.Text = "Processing " + Convert.ToString(i + 1) + " / " + Convert.ToString(Total_Record) + "  ";
        }
    
        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
    
                DataTable dt = e.Result as DataTable;
                Grid_records.DataSource = e.Result;
        }
    
        public DataTable check_number(DataSet ds)
        {
            // Do whatever is needed
        }
    }
